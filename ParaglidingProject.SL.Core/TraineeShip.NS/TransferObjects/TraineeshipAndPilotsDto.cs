using ParaglidingProject.SL.Core.Pilot.NS.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.SL.Core.TraineeShip.NS.TransferObjects
{
   public class TraineeshipAndPilotsDto
    {
        public TraineeShipDto TraineeshipDto { get; set; }
        public IReadOnlyCollection<PilotDto> PilotsDto { get; set; }
    }
}
