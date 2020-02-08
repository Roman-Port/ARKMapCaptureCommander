using RomanPort.ARKMapCaptureCommander.Framework.Communication.QueryAllCmdReturn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.ARKMapCaptureCommander.Framework.Communication.Packets
{
    public class ArkEventPacket_5_UpdateActorProps : ArkEventPacket
    {
        public int index;
        public QueriedActorData data;
    }
}
