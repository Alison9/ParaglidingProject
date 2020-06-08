using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParaglidingProject.Data;
using ParaglidingProject.SL.Core.Flights.NS.TransfertObjects;

namespace ParaglidingProject.SL.Core.Flights.NS
{
    public class FlightsService : IFlightsService
    {
        private readonly ParaglidingClubContext _paraContext;
        public FlightsService(ParaglidingClubContext paraContext)
        {
            _paraContext = paraContext ?? throw new ArgumentNullException(nameof(paraContext));
        }

        public async Task<IReadOnlyCollection<FlightDto>> GetAllFlightsAsync()
        {
            var flights = _paraContext.Flights
                 .AsNoTracking()
                 .Select(f => new FlightDto
                 {
                     FlightId = f.ID,
                     FlightDate = f.FlightDate,
                     Duration = f.Duration,
                     PilotName = $"{f.Pilot.FirstName} {f.Pilot.LastName}",
                     ParagliderName = f.Paraglider.Name,
                     TakeOffSiteName = f.TakeOffSite.Name,
                     LandingSiteName = f.LandingSite.Name
                 });

            return await flights.ToListAsync();

        }

        public async Task<FlightDto> GetFlightAsync(int id)
        {
            var flight = _paraContext.Flights
                .AsNoTracking()
                .Select(f => new FlightDto
                {
                    FlightId = f.ID,
                    FlightDate = f.FlightDate,
                    Duration = f.Duration,
                    PilotName = $"{f.Pilot.FirstName} {f.Pilot.LastName}",
                    ParagliderName = f.Paraglider.Name,
                    TakeOffSiteName = f.TakeOffSite.Name,
                    LandingSiteName = f.LandingSite.Name
                })
                .FirstOrDefaultAsync(f => f.FlightId == id);


            return await flight;
        }
    }
}
