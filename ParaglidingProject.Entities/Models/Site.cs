using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class Site
    {
        public int ID { get; set; }
        [Display(Name="Nom du site")]
        public string Name { get; set; }
        [Display(Name="Orientation au décollage")]
        public string OrientationLanding{ get; set; }
        [Display(Name = "Orientation à l'atterrisage")]
        public string OrientationTakeOff { get; set; } // variable type spatial (longitude/latitude)
        [Display(Name = "Altitude")]
        public int? AltitudeTakeOff { get; set; }
        [Display(Name = "Type de vol")]
        public string FlightType { get; set; }
        [Display(Name = "Niveau requis")]
        public int LevelID { get; set; }
        [Display(Name="Historique des vols")]
        public ICollection<Flight> Flights { get; set; }
        [Display(Name = "Niveau requis")]
        public Level Level { get; set; }
    }
}
