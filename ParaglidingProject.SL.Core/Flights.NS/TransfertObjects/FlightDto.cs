using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.SL.Core.Flights.NS.TransfertObjects
{
    public class FlightDto
    {
        public int FlightId { get; set; }
        public DateTime FlightDate { get; set; }
        public decimal Duration { get; set; }
        public string PilotName { get; set; }
        public string ParagliderName { get; set; }
        public string TakeOffSiteName { get; set; }
        public string LandingSiteName { get; set; }
        public int ParagliderId { get; set; }

    }
}
