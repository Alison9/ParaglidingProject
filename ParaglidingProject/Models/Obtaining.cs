using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class Obtaining
    {
        public int ID { get; set; }
        public int PilotID { get; set; }
        public int LicenseID { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ObtainingDate { get; set; }
        public bool IsSucced { get; set; }
        public Pilot Pilot { get; set; }
        public License License { get; set; }
        
    }
}
