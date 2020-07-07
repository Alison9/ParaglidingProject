using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.TraineeShip.NS.TransferObjects
{
    public class TraineeshipPatchDto
    {
        public DateTime TraineeShipStartDate { get; set; }
       
        public DateTime TraineeShipEndDate { get; set; }
        public decimal TraineeShipPrice { get; set; }

        public bool ValidateBusinessLogic()
        {
            if (TraineeShipPrice <= 0 ) return false;
            if (TraineeShipEndDate <= TraineeShipStartDate) return false;
            return true;
        }
        

    }
}
