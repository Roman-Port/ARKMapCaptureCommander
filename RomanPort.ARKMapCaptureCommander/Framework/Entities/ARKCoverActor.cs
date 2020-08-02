using Newtonsoft.Json;
using RomanPort.ARKMapCaptureCommander.Framework.Communication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.ARKMapCaptureCommander.Framework.Entities
{
    /// <summary>
    /// Wrapper for cover objects
    /// </summary>
    public class ARKCoverActor
    {
        private int cover_index;
        private bool ready;
        private ServerCommunicationTool comm;

        public string title;
        public CoverTransform transform;

        public ARKCoverActor(ServerCommunicationTool comm, string title, CoverTransform transform)
        {
            //Set
            this.comm = comm;
            ready = false;
            this.transform = transform;
            this.title = title;

            //Create
            comm.CmdCreateCover(OnCreateResponse);
        }

        public void UpdateTransform()
        {
            if(ready)
                comm.CmdModifyCover(cover_index, transform);
        }

        private void OnCreateResponse(string payload)
        {
            CreateCoverResponse response = JsonConvert.DeserializeObject<CreateCoverResponse>(payload);
            cover_index = response.index;
            ready = true;
            UpdateTransform();
        }

        class CreateCoverResponse
        {
            public int index;
        }
    }
}
