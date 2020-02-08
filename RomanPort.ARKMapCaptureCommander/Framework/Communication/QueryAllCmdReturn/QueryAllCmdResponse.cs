using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.ARKMapCaptureCommander.Framework.Communication.QueryAllCmdReturn
{
    public class QueryAllCmdResponse
    {
        public QueriedActorData[] actors;
    }

    public class QueriedActorData
    {
        [JsonProperty("n")]
        public string name;
        [JsonProperty("c")]
        public string type;
        [JsonProperty("h")]
        public bool hidden;
        [JsonProperty("i")]
        public int index;

        [JsonProperty("ol")]
        public QueriedActorData_Light data_light;
        [JsonProperty("op")]
        public JObject data_postprocess;
    }

    public class QueriedActorData_Light
    {
        [JsonProperty("i")]
        public float intensity;
    }
}
