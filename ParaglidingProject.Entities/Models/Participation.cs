using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class Participation
    {
        public int ID { get; set; }
        public int PilotID { get; set; }
        public int CourseID { get; set; }
        [Display(Name ="Date de payments")]
        [DataType(DataType.Date)]
        public DateTime DateOfParticipation { get; set; }
        [Display(Name = "Payé?")]
        public bool IsPay { get; set; }
        public Pilot Pilot { get; set; }
        public Course Course { get; set; }
    }
}
