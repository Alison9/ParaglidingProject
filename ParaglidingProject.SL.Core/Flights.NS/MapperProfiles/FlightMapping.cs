using ParaglidingProject.Models;
using ParaglidingProject.SL.Core.Flights.NS.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.SL.Core.Flights.NS.MapperProfiles
{
    public static class FlightMapping
    {
        public static FlightDto MapFlightDto(this Flight flight)
        {
            var flightDto = new FlightDto
            {
                FlightId = flight.ID,
                FlightDate = flight.FlightDate,
                Duration = flight.Duration,
                PilotName = $"{flight.Pilot.FirstName} {flight.Pilot.LastName}",
                ParagliderName = flight.Paraglider.Name,
                TakeOffSiteName = flight.TakeOffSite.Name,
                LandingSiteName = flight.LandingSite.Name
            };
            return flightDto;
        }
    }
}
