using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class Flight
    {
        public int ID { get; set; }
        [Display(Name="Date du vol")]
        [DataType(DataType.Date)]
        public DateTime FlightDate { get; set; }
        public decimal Duration { get; set; }
        public int PilotID { get; set; }
        [Display(Name = "Numéro du parapente")]
        public int ParagliderID { get; set; }
        [Display(Name ="Site")]
        public int SiteID { get; set; }
        [Display(Name = "Pilote")]
        public Pilot Pilot { get; set; }
        public Paraglider Paraglider { get; set; }
        public Site Site { get; set; }


    }
}
