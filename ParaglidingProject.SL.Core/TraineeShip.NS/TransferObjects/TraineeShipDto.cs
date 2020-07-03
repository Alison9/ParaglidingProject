using ParaglidingProject.Models;
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
            public bool TraineeshipIsActive { get; set; }
            public int LicenseId { get; set; }
            public License License { get; set; }


    }
    }

