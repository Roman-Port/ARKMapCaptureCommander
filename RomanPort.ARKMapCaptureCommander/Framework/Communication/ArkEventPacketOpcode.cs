using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.ARKMapCaptureCommander.Framework.Communication
{
    public enum ArkEventPacketOpcode
    {
        WriteToOutput = 0,
        MoveCamera = 1,
        SetCameraProps = 2,
        RemoveUnessessaryActors = 3,
        QueryAllActors = 4,
        UpdateActorProps = 5
    }
}
