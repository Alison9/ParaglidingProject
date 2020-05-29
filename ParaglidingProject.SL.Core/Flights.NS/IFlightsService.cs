using ParaglidingProject.SL.Core.Flights.NS.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.Flights.NS
{
    public interface IFlightsService
    {
        Task<FlightDto> GetFlightAsync(int id);
        Task<IReadOnlyCollection<FlightDto>> GetAllFlightsAsync();
    }
}
