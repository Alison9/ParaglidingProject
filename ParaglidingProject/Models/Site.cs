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

        [Display(Name="Nom")]
        [Required]
        [MaxLength(50 ,ErrorMessage="Le maximum de caractères est de 50")]
        public string Name { get; set; }
        [Display(Name="Orientation pour l'atterrissage")]
        public string OrientationLanding{ get; set; }

        [Display(Name="Orientation pour le décollage")]
        public string OrientationTakeOff { get; set; } // variable type spatial (longitude/latitude)

        [Display(Name="Altitude au décollage")]
        public int? AltitudeTakeOff { get; set; }

        [Display(Name="Type de vol")]
        public string FlightType { get; set; }

        public int LevelID { get; set; }
        public ICollection<Flight> Flights { get; set; }
        public Level Level { get; set; }
    }
}
