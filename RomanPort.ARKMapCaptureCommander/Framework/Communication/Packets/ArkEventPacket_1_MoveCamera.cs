using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.ARKMapCaptureCommander.Framework.Communication.Packets
{
    public class ArkEventPacket_1_MoveCamera : ArkEventPacket
    {
        public float x;
        public float y;
        public float z;
        public float pitch;
        public float yaw;
        public float roll;
        public bool callback_enabled;
        public int callback_id;
    }
}
