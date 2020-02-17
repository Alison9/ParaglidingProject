using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class Payment
    {
        public int ID { get; set; }
        public int PilotID { get; set; }
        public int SubsciptionID { get; set; }
        public bool IsPay { get; set; }
        public DateTime? DatePay { get; set; }
        public Pilot Pilot { get; set; }
        public Subscription Subscription { get; set; }
    }
}
