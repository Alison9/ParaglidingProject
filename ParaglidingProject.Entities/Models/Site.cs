using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static ParaglidingProject.Models.Enumeration;

namespace ParaglidingProject.Models
{
  public  enum typesite
    {
        takeoff=1,
        landing=2
    }


    public class Site
    {
        public int ID { get; set; }
        [Display(Name="Nom du site")]
        public string Name { get; set; }
        [Display(Name = "Orientation à l'atterrisage")]
        public string Orientation { get; set; } // variable type spatial (longitude/latitude)
        [Display(Name = "Altitude")]
        public int AltitudeTakeOff { get; set; }
        public string ApproachManeuver { get; set; }
        public string SiteGeoCoordinate { get; set; }
        public Enm_SiteType SiteType { get; set; }// column de descrimimation

        [Display(Name = "Niveau requis")]
        public int LevelID { get; set; }
        [Display(Name="Historique des vols")]
        public ICollection<Flight> TakeOffFlights { get; set; }
        public ICollection<Flight> LandingFlights { get; set; }
        [Display(Name = "Niveau requis")]
        public Level Level { get; set; }
        public bool IsActive { get; set; }
    }
}
