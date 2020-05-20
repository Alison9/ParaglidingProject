using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class TraineeshipPayment
    {
        //public int ID { get; set; }
        public int PilotID { get; set; }
        public int TraineeshipID { get; set; }
        [Display(Name ="Date de payments")]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }
        [Display(Name = "Payé?")]
        public bool IsPaid { get; set; }
        public Pilot Pilot { get; set; }
        public Traineeship Traineeship { get; set; }
    }
}
