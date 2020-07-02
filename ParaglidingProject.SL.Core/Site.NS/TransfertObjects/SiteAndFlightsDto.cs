using ParaglidingProject.SL.Core.Flights.NS.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.SL.Core.Site.NS.TransfertObjects
{
    public class SiteAndFlightsDto
    {
        public SiteDto SiteDto { get; set; }
        public IReadOnlyCollection<FlightDto> FlightsDto { get; set; }
    }
}
