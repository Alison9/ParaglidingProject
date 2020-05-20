using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class Possession
    {
        public int ID { get; set; }
        public int PilotID { get; set; }
        public int LicenceID { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExamDate { get; set; }
        public bool IsSucceeded { get; set; }
        public bool IsActive { get; set; }
        public Pilot Pilot { get; set; }
        public License License { get; set; }
        
    }
}
