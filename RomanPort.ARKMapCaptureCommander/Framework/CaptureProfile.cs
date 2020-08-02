using Newtonsoft.Json.Linq;
using RomanPort.ARKMapCaptureCommander.Framework.Communication.QueryAllCmdReturn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.ARKMapCaptureCommander.Framework
{
    public class CaptureProfile
    {
        public int version = 0;

        public string name = "";

        public int offsetX = 0;
        public int offsetY = 0;
        public int mapSize = 1000;
        public int zoomLevels = 6;
        public int cameraHeight = 400000;
        public float rotation = -90;
        public string output = "";

        public List<CaptureProfileActorParams> actors = new List<CaptureProfileActorParams>();
    }

    public class CaptureProfileActorParams
    {
        public string query; //The string used to find the actor
        public int queryType; //0: Name, 1: Type

        public bool hidden;
        public QueriedActorData_Light data_light;
        public JObject data_postprocess;
    }
}
