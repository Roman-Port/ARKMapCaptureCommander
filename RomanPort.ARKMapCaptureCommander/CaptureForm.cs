using RomanPort.ARKMapCaptureCommander.Framework;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        int drawCommandIndex = 0;
        float lastZoomValue = -1;
        ConcurrentQueue<Tuple<string, Bitmap>> queuedRenders; //Holds captured screenshots for rendering on a seperate thread
        int computedExportTiles = 0;

        public CaptureForm()
        {
            InitializeComponent();

            //Compute draw commands
            moveCommands = CalculateMoveCommands();
            queuedRenders = new ConcurrentQueue<Tuple<string, Bitmap>>();
            for(int i = 0; i<8; i++)
            {
                var proc = new Thread(ProcessQueue);
                proc.IsBackground = true;
                proc.Start();
            }

            HandleCreated += CaptureForm_HandleCreated;
        }

        private void CaptureForm_HandleCreated(object sender, EventArgs e)
        {
            RunNextCommand();
        }

        private static List<CameraMoveCommand> CalculateMoveCommands()
        {
            List<CameraMoveCommand> cmds = new List<CameraMoveCommand>();
            float halfMapSize = Program.profile.mapSize / 2f;
            for(int i = 0; i<Program.profile.zoomLevels; i++)
            {
                int dimenElements = (int)Math.Pow(2, i); //Number of elements in each dimen
                float captureSize = (float)Program.profile.mapSize / (float)dimenElements; //Size of each capture in game units. Also used as zoom size
                for(int x = 0; x<dimenElements; x++)
                {
                    for(int y = 0; y<dimenElements; y++)
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

        private void RunNextCommand()
        {
            //Get next step
            var cmd = moveCommands[drawCommandIndex];
            drawCommandIndex++;

            //Update UI
            Invoke((MethodInvoker) delegate
            {
                progressBar1.Maximum = moveCommands.Count;
                progressBar1.Value = drawCommandIndex;
                statusLabel.Text = $"Rendering {drawCommandIndex}/{moveCommands.Count} ({Math.Round(((float)drawCommandIndex / (float)moveCommands.Count) * 100)}%)";
            });

            //Check if we need to change the size
            if (lastZoomValue != cmd.z)
                Program.comms.CmdSetCameraProps(cmd.z);
            lastZoomValue = cmd.z;

            //Move the camera
            Program.comms.CmdMoveCamera(cmd.x, cmd.y, Program.profile.cameraHeight, Program.profile.rotation, (string r) =>
            {
                //Delay to allow render
                Thread.Sleep(50);

                //Capture image
                Bitmap bp = CaptureTool.PrintWindow(Program.process);

                //Check for the "loading..." message. Search it's blue in the bottom right with a timeout
                for(int i = 0; i<200; i++)
                {
                    bool match = false;
                    for(int x = bp.Height / 2; x<bp.Width; x++)
                    {
                        for (int y = bp.Height / 2; y < bp.Height; y++)
                        {
                            var p = bp.GetPixel(x, y);
                            if (p.R == 1 && p.G == 211 && p.B == 213)
                                match = true;
                        }
                    }
                    if (match)
                    {
                        Thread.Sleep(20);
                        bp = CaptureTool.PrintWindow(Program.process);
                        continue;
                    }
                    break;
                }

                //Delay to allow further render
                Thread.Sleep(130);
                bp = CaptureTool.PrintWindow(Program.process);

                //Queue
                queuedRenders.Enqueue(new Tuple<string, Bitmap>(cmd.name, bp));
                RunNextCommand();
            });
        }

        /// <summary>
        /// This runs on the process queue thread
        /// </summary>
        public void ProcessQueue()
        {
            while(computedExportTiles < moveCommands.Count)
            {
                //Get data
                Tuple<string, Bitmap> result;
                while (!queuedRenders.TryDequeue(out result)) ;

                //Convert image
                var img = CaptureTool.ConvertBitmapToImage(result.Item2);

                //Resize to shipping
                img.Mutate(x => x.Resize(256, 256));
                img.Mutate(x => x.Saturate(1.2f));

                //Save to file
                using (FileStream fs = new FileStream("output\\" + result.Item1 + ".png", FileMode.Create))
                {
                    img.SaveAsPng(fs, new SixLabors.ImageSharp.Formats.Png.PngEncoder
                    {
                        CompressionLevel = 9
                    });
                }

                //Update
                computedExportTiles++;
                Invoke((MethodInvoker)delegate
                {
                    renderStatusBar.Maximum = moveCommands.Count;
                    renderStatusBar.Value = computedExportTiles;
                    renderStatusText.Text = $"Exporting {computedExportTiles}/{moveCommands.Count} ({Math.Round(((float)computedExportTiles / (float)moveCommands.Count) * 100)}%)";
                });
            }
        }

        private void CaptureWindowScreenshot(string output)
        {
            //Get screengrab
            var img = CaptureTool.CaptureProcessWindow(Program.process);

            //Resize to shipping
            img.Mutate(x => x.Resize(256, 256));

            //Save to file
            using(FileStream fs = new FileStream(output, FileMode.Create))
            {
                img.SaveAsPng(fs, new SixLabors.ImageSharp.Formats.Png.PngEncoder
                {
                    CompressionLevel = 9
                });
            }
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
