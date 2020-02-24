using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class Course
    {
        public int ID { get; set; }

        [Display(Name="Date d'entrée")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Date de fin")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Display(Name = "Prix du cours")]
        public decimal CoursePrice { get; set; }
        public int LicenseID { get; set; }
        public ICollection<Participation> Participations { get; set; }
        public ICollection<Teaching> Teachings { get; set; }
        [Display(Name = "Brevet délivré")]
        public License License { get; set; }
    }
}
