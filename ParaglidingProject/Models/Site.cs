using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParaglidingProject.Models
{
    public class Site
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string OrientationLanding{ get; set; }
        public string OrientationTakeOff { get; set; } // variable type spatial (longitude/latitude)
        public int? AltitudeTakeOff { get; set; }
        public string FlightType { get; set; }
        public int LevelID { get; set; }
        public ICollection<Flight> Flights { get; set; }
        public Level Level { get; set; }
    }
}
