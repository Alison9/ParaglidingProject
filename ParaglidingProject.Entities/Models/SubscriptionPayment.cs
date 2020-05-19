using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class SubscriptionPayment
    {
      
        [Display(Name="Pilote")]
        public int PilotID { get; set; }
        public int SubsciptionID { get; set; }
        [Display(Name = "Date de payement")]
        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DatePay { get; set; }
        public Pilot Pilot { get; set; }
        public Subscription Subscription { get; set; }
    }
}
