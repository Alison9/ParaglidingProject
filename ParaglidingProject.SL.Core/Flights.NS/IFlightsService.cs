using ParaglidingProject.SL.Core.Flights.NS.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ParaglidingProject.Models;

namespace ParaglidingProject.SL.Core.Flights.NS
{
    public interface IFlightsService
    {
        Task<FlightDto> GetFlightAsync(int id);
        Task<IReadOnlyCollection<FlightDto>> GetAllFlightsAsync();
        Task<IReadOnlyCollection<FlightDto>> GetAllFlightsForPilotInDateRangeAsync(int pilotId, DateRangeParams dates);
    }
}
