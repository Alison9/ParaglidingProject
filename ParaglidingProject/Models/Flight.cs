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

        [DataType(DataType.Time)]
        public DateTime FlightDate { get; set; }

        [DataType(DataType.Time)]
        public DateTime FlightStart { get; set; }

        [DataType(DataType.Time)]
        public DateTime FlightEnd { get; set; }

        public int PilotID { get; set; }
        public int ParaglidingID { get; set; }
        public int SiteID { get; set; }
        [Display(Name="Pilote")]
        public Pilot Pilot { get; set; }
        [Display(Name= "Parapente")]
        public Paragliding Paragliding { get; set; }
        [Display(Name="Site")]
        public Site Site { get; set; }


    }
}
