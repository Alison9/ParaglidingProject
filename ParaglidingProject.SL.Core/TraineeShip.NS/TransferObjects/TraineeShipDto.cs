using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParaglidingProject.SL.Core.TraineeShip.NS.TransferObjects
{
      public class TraineeShipDto
    {
       
            public int Traineeshipid { get; set; }
            [DataType(DataType.Date)]
            public DateTime TraineeShipStartDate { get; set; }
            [DataType(DataType.Date)]
             public DateTime TraineeShipEndDate { get; set; }
            public decimal TraineeShipPrice { get; set; }
            public bool traineeshipIsActive { get; set; }
            

        }
    }

