using Microsoft.EntityFrameworkCore.Metadata;
using ParaglidingProject.SL.Core.Flights.NS.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.SL.Core.Paraglider.NS.TransfertObjects
{
    public class ParagliderAndFlightsDto
    {
        public ParagliderDto ParagliderDto { get; set; }
        public ICollection<FlightDto> FlightsDto { get; set; }
    }
}
