using RomanPort.ARKMapCaptureCommander.Framework;
using RomanPort.ARKMapCaptureCommander.Framework.Entities;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanPort.ARKMapCaptureCommander
{
    public partial class CaptureForm : Form
    {
        List<CameraMoveCommand> moveCommands;
        float lastZoomValue = -1;
        int waterTileCount;
        int normalTileCount; //does not include water

        public CaptureForm()
        {
            InitializeComponent();

            //Compute draw commands
            moveCommands = CalculateMoveCommands();

            HandleCreated += CaptureForm_HandleCreated;
        }

        private void CaptureForm_HandleCreated(object sender, EventArgs e)
        {
            Thread worker = new Thread(() =>
            {
                BeginProcessing();
            });
            worker.IsBackground = true;
            worker.Start();
        }

        private static List<CameraMoveCommand> CalculateMoveCommands()
        {
            List<CameraMoveCommand> cmds = new List<CameraMoveCommand>();
            float halfMapSize = Program.profile.mapSize / 2f;
            for (int i = 0; i < Program.profile.zoomLevels + 1; i++)
            {
                int dimenElements = (int)Math.Pow(2, i); //Number of elements in each dimen
                float captureSize = (float)Program.profile.mapSize / (float)dimenElements; //Size of each capture in game units. Also used as zoom size
                for (int x = 0; x < dimenElements; x++)
                {
                    for (int y = 0; y < dimenElements; y++)
                    {
                        float cmdX = captureSize * x; //Offset in game units
                        float cmdY = captureSize * y; //Offset in game units
                        cmdX += (captureSize / 2);
                        cmdY += (captureSize / 2);
                        cmdX -= halfMapSize;
                        cmdY -= halfMapSize;
                        cmdX += Program.profile.offsetX;
                        cmdY += Program.profile.offsetY;
                        cmds.Add(new CameraMoveCommand
                        {
                            x = cmdX,
                            y = cmdY,
                            z = captureSize,
                            name = $"{i}_{x}_{y}"
                        });
                    }
                }
            }
            return cmds;
        }

        private void BeginProcessing()
        {
            //Allocate our primary bitmap and space to store it's name
            DirectBitmap primaryBitmap = CaptureTool.GetEmptyBitmapFromWindowRect(Program.process);
            string previousFrameName = null;

            //Open the log file. This holds values of the diffs
            FileStream logFile = new FileStream(Program.profile.output.TrimEnd('\\') + "\\diffs.txt", FileMode.Create);

            //Status
            int resent = 0;
            double averageTileTimeMs = 0;

            //Run to completion
            for (int i = 0; i < moveCommands.Count; i++)
            {
                //Get next step
                var cmd = moveCommands[i];

                //Update UI
                Invoke((MethodInvoker)delegate
                {
                    progressBar1.Maximum = moveCommands.Count;
                    progressBar1.Value = i;
                    statusLabel.Text = $"Rendering {i}/{moveCommands.Count} ({Math.Round(((float)i / (float)moveCommands.Count) * 100, 2)}%)";
                    if(i > 0)
                        statWaterTiles.Text = $"{waterTileCount} ({Math.Round(((float)waterTileCount / (float)i) * 100, 2)}%)";
                });

                //Check if we need to change the size
                if (lastZoomValue != cmd.z)
                    Program.comms.CmdSetCameraProps(cmd.z);
                lastZoomValue = cmd.z;

                //Move the camera
                DateTime processBegin = DateTime.UtcNow;
                bool waiting_image = true;
                bool waiting_process = true;
                var packet = Program.comms.CmdMoveCamera(cmd.x, cmd.y, Program.profile.cameraHeight, Program.profile.rotation, (string r) =>
                {
                    //Render the previous frame while we wait for ARK to catch up
                    TimeSpan arkPing = DateTime.UtcNow - processBegin;
                    DateTime delayBegin = DateTime.UtcNow;
                    while (waiting_process)
                        Thread.Sleep(2);

                    //Log
                    Invoke((MethodInvoker)delegate
                    {
                        statusLastProcessingTime.Text = ((int)(DateTime.UtcNow - processBegin).TotalMilliseconds).ToString();
                        statusArkPing.Text = ((int)arkPing.TotalMilliseconds).ToString();
                    });

                    //Wait
                    int remainingDelay = 200 - (int)(DateTime.UtcNow - delayBegin).TotalMilliseconds;
                    if (remainingDelay > 1)
                        Thread.Sleep(remainingDelay);

                    //Get the total time waited
                    double totalTimeWaited = (DateTime.UtcNow - processBegin).TotalMilliseconds;
                    if (averageTileTimeMs == 0)
                        averageTileTimeMs = totalTimeWaited;
                    else
                        averageTileTimeMs = (totalTimeWaited + averageTileTimeMs) / 2f;

                    //Log
                    Invoke((MethodInvoker)delegate
                    {
                        double remainingMs = (moveCommands.Count - i) * averageTileTimeMs;
                        TimeSpan remaining = new TimeSpan(0, 0, (int)(remainingMs / 1000));
                        statusTimeRemaining.Text = ((remaining.Days * 24) + remaining.Hours).ToString().PadLeft(2, '0') + ":" + remaining.Minutes.ToString().PadLeft(2, '0') + ":" + remaining.Seconds.ToString().PadLeft(2, '0');
                    });

                    //Capture final
                    CaptureTool.PrintWindowToBitmap(Program.process, primaryBitmap);

                    //Queue this for rendering
                    //We can just reuse the existing primary bitmap because it will be untouched while processing
                    previousFrameName = cmd.name;

                    //Ready
                    waiting_image = false;
                });

                //Begin previous image saving
                if (previousFrameName != null)
                    SaveProcessedImage(logFile, previousFrameName, primaryBitmap);
                waiting_process = false;

                //Wait
                int cycles = 0;
                while (waiting_image)
                {
                    if (cycles == 1000)
                    {
                        //Resend
                        Program.comms.ResendDropped(packet);
                        resent++;
                        Invoke((MethodInvoker)delegate
                        {
                            statusResentCount.Text = resent.ToString();
                        });
                        cycles = 0;
                    }
                    Thread.Sleep(2);
                    cycles++;
                }
            }

            //Save the final frame
            if (previousFrameName != null)
                SaveProcessedImage(logFile, previousFrameName, primaryBitmap);

            //Dispose
            primaryBitmap.Dispose();
            logFile.Close();
        }

        private void SaveProcessedImage(FileStream logStream, string name, DirectBitmap bitmap)
        {
            //Convert image
            var img = CaptureTool.ConvertBitmapToImage(bitmap, out int maxDiff);

            //Determine if this is a water tile
            bool water = maxDiff <= 2;

            //Write stats
            if (water)
                waterTileCount++;
            else
                normalTileCount++;

            //Only save if this isn't a water tile
            if (!water)
            {
                //Resize to shipping
                img.Mutate(x => x.Resize(256, 256).Saturate(1.2f));

                //Save to file
                using (FileStream fs = new FileStream(Program.profile.output.TrimEnd('\\') + "\\" + name + ".png", FileMode.Create))
                {
                    img.SaveAsPng(fs, new SixLabors.ImageSharp.Formats.Png.PngEncoder
                    {
                        CompressionLevel = 9
                    });
                }
            }

            //Write log to file
            byte[] log = Encoding.UTF8.GetBytes($"{name} {maxDiff}\n");
            logStream.Write(log, 0, log.Length);
            logStream.Flush();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        struct CameraMoveCommand
        {
            public float x;
            public float y;
            public float z;
            public string name;
        }
    }
}
