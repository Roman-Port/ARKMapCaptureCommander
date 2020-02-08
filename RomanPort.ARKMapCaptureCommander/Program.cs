using RomanPort.ARKMapCaptureCommander.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanPort.ARKMapCaptureCommander
{
    static class Program
    {
        public static ServerCommunicationTool comms;
        public static CaptureProfile profile;
        public static Process process;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*var e = Framework.CaptureTool.CaptureProcessWindow(System.Diagnostics.Process.GetProcessById(28688));
            using (System.IO.FileStream fs = new System.IO.FileStream("test.png", System.IO.FileMode.Create))
                e.Save(fs, new SixLabors.ImageSharp.Formats.Png.PngEncoder());*/

            comms = new ServerCommunicationTool();
            profile = new CaptureProfile();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ConfigForm());
        }
    }
}
