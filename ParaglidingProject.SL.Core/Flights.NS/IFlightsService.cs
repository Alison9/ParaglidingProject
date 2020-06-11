using ParaglidingProject.SL.Core.Flights.NS.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ParaglidingProject.Models;

namespace ParaglidingProject.SL.Core.Flights.NS
{
    /// <summary>
    /// Flight's contract manager
    /// </summary>
    public interface IFlightsService
    {
        /// <summary>
        /// Return a specific flight if it is avalable
        /// </summary>
        /// <param name="id">The unique flight's id as integer</param>
        /// <returns> a FlightDto containing the flightId,flightDate,Duration,PilotName,ParagliderName,TakeOff and Landing sites </returns>
        Task<FlightDto> GetFlightAsync(int id);
        /// <summary>
        /// Return all avalaible flights
        /// </summary>
        /// <returns>A ReadOnlycollection of FlightDto containing the flightId,flightDate,Duration,PilotName,ParagliderName,TakeOff and Landing sites </returns>
        Task<IReadOnlyCollection<FlightDto>> GetAllFlightsAsync();
        /// <summary>
        /// Get all avalaible flights for a pilot in a range of date
        /// </summary>
        /// <param name="pilotId">The unique PilotId as integer</param>
        /// <param name="dates">The date range as a DateRangeParams(BeginDate and EndDate)</param>
        /// <returns>A ReadOnlyCollection of FlightDto containing the flightId,flightDate,Duration,PilotName,ParagliderName,TakeOff and Landing sites </returns>
        Task<IReadOnlyCollection<FlightDto>> GetAllFlightsForPilotInDateRangeAsync(int pilotId, DateRangeParams dates);
    }
}
