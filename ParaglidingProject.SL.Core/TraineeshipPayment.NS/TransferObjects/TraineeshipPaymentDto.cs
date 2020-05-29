using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.SL.Core.TraineeshipPayement.NS.TransferObjects
{
    public class TraineeshipPaymentDto
    {
        public int PilotId { get; set;}
        public int TraineeshipID { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsPaid { get; set; }

        //pilot et traineeship
    }
}
