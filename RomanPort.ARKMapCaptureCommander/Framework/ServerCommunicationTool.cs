using Newtonsoft.Json;
using RomanPort.ARKMapCaptureCommander.Framework.Communication;
using RomanPort.ARKMapCaptureCommander.Framework.Communication.Entities;
using RomanPort.ARKMapCaptureCommander.Framework.Communication.Packets;
using RomanPort.ARKMapCaptureCommander.Framework.Communication.QueryAllCmdReturn;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.ARKMapCaptureCommander.Framework
{
    public delegate void ServerCommsCallback(string data);
    
    public class ServerCommunicationTool
    {
        public HttpListener server;
        public List<ArkEventPacket> events;
        private Dictionary<int, ServerCommsCallback> registeredCallbacks;
        private Random rand;

        public ServerCommunicationTool()
        {
            events = new List<ArkEventPacket>();
            rand = new Random();
            registeredCallbacks = new Dictionary<int, ServerCommsCallback>();
            server = new HttpListener();
            server.Prefixes.Add("http://localhost:44401/");
            server.Start();
            server.BeginGetContext(OnGetContext, null);
            CmdShowLogMessage("Connected to server!");
        }

        private int RegisterCallback(ServerCommsCallback cb)
        {
            //Generate a random ID
            int id = rand.Next(0, 99999);
            while(registeredCallbacks.ContainsKey(id))
                id = rand.Next(0, 99999);

            //Register
            registeredCallbacks.Add(id, cb);

            return id;
        }

        public void CmdShowLogMessage(string msg)
        {
            events.Add(new ArkEventPacket_0_ConsoleLogMessage
            {
                opcode = ArkEventPacketOpcode.WriteToOutput,
                message = msg
            });
        }

        public void CmdMoveCamera(float x, float y, float z, float rot, ServerCommsCallback callback = null)
        {
            var e = new ArkEventPacket_1_MoveCamera
            {
                opcode = ArkEventPacketOpcode.MoveCamera,
                x = x,
                y = y,
                z = z,
                roll = 0,
                pitch = -90,
                yaw = rot,
                callback_enabled = false 
            };

            if (callback != null)
            {
                e.callback_id = RegisterCallback(callback);
                e.callback_enabled = true;
            }

            events.Add(e);
        }
        
        public void CmdQueryAllActors(ServerCommsCallback callback)
        {
            events.Add(new ArkEventPacket_4_QueryAllActors
            {
                callback_id = RegisterCallback(callback),
                opcode = ArkEventPacketOpcode.QueryAllActors
            });
        }

        public void CmdSetCameraProps(float width)
        {
            events.Add(new ArkEventPacket_2_SetCameraProps
            {
                opcode = ArkEventPacketOpcode.SetCameraProps,
                width = width
            });
        }
        
        public void CmdRemoveUnessessaryActors()
        {
            events.Add(new ArkEventPacket
            {
                opcode = ArkEventPacketOpcode.RemoveUnessessaryActors
            });
        }

        public void CmdUpdateActorProps(QueriedActorData data, int index)
        {
            events.Add(new ArkEventPacket_5_UpdateActorProps
            {
                data = data,
                index = index,
                opcode = ArkEventPacketOpcode.UpdateActorProps
            });
        }

        public void CmdCreateCover(ServerCommsCallback callback)
        {
            var e = new ArkEventPacket_6_CmdCreateCover
            {
                opcode = ArkEventPacketOpcode.CreateCover,
                callback_id = RegisterCallback(callback)
            };

            events.Add(e);
        }

        public void CmdModifyCover(int index, CoverTransform transform)
        {
            var e = new ArkEventPacket_7_CmdModifyCover
            {
                opcode = ArkEventPacketOpcode.ModifyCover,
                cover_index = index,
                transform = transform
            };

            events.Add(e);
        }

        private void OnGetContext(IAsyncResult ar)
        {
            //Get context
            var ctx = server.EndGetContext(ar);

            //Switch on type
            try
            {
                switch (ctx.Request.HttpMethod.ToUpper())
                {
                    case "GET": OnHTTPGet(ctx); break;
                    case "POST": OnHTTPPost(ctx); break;
                }
            } catch
            {
                Console.WriteLine("ERROR in OnGetContext");
            }

            //Get next
            ctx.Response.Close();
            server.BeginGetContext(OnGetContext, null);
        }

        private void OnHTTPGet(HttpListenerContext ctx)
        {
            //Create data
            string data;
            lock (events)
            {
                //Create response data
                ResponseData d = new ResponseData
                {
                    events = events
                };

                //JSON encode
                data = "RPMAP" + JsonConvert.SerializeObject(d);
                Console.WriteLine("SENDING " + events.Count + " events.");

                //Clear event cache
                events.Clear();
            }

            //Send data
            byte[] bdata = Encoding.UTF8.GetBytes(data);
            ctx.Response.OutputStream.Write(bdata, 0, bdata.Length);
        }

        private void OnHTTPPost(HttpListenerContext ctx)
        {
            //Read callback ID
            int id = int.Parse(ctx.Request.QueryString.Get("callback"));

            //Read callback data
            string data;
            using (StreamReader sr = new StreamReader(ctx.Request.InputStream))
                data = sr.ReadToEnd();

            //Run callback
            registeredCallbacks[id](data);
            registeredCallbacks.Remove(id);
        }

        private class ResponseData
        {
            public List<ArkEventPacket> events;
        }
    }
}
