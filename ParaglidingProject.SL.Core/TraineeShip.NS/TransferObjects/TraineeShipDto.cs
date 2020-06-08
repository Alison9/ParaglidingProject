using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.SL.Core.TraineeShip.NS.TransferObjects
{
      public class TraineeShipDto
    {
       
            public int Traineeshipid { get; set; }
            public DateTime TraineeShipStartDate { get; set; }
            public DateTime TraineeShipEndDate { get; set; }
            public decimal TraineeShipPrice { get; set; }
            public bool traineeshipIsActive { get; set; }
            

        }
    }

