using RomanPort.ARKMapCaptureCommander.Framework.Communication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.ARKMapCaptureCommander.Framework.Communication.Packets
{
    public class ArkEventPacket_7_CmdModifyCover : ArkEventPacket
    {
        public int cover_index;
        public CoverTransform transform;
    }
}
