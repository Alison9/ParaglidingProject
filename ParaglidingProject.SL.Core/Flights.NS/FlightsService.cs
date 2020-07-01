using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParaglidingProject.Data;
using ParaglidingProject.Models;
using ParaglidingProject.SL.Core.Flights.NS.Helpers;
using ParaglidingProject.SL.Core.Flights.NS.MapperProfiles;
using ParaglidingProject.SL.Core.Flights.NS.TransfertObjects;
using ParaglidingProject.SL.Core.Helpers;

namespace ParaglidingProject.SL.Core.Flights.NS
{
    /// <inheritdoc/>
    public class FlightsService : IFlightsService
    {
        private readonly ParaglidingClubContext _paraContext;
        public FlightsService(ParaglidingClubContext paraContext)
        {
            _paraContext = paraContext ?? throw new ArgumentNullException(nameof(paraContext));
        }
        public async Task<IReadOnlyCollection<FlightDto>> GetAllFlightsAsync(FlightsSSFP options)
        {
            var flights = _paraContext.Flights
                 .AsNoTracking()
                 .FilterFlightBy(options.FilterBy, options.TakeOffSiteId, options.LandingSiteId,options.ParagliderId)
                 .SortFlightBy(options.SortBy)
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

            options.SetPagingValues(flights);

            var pageQuery = flights.Page(options.PageNumber - 1, options.PageSize);

            return await pageQuery.ToListAsync();

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

        public async Task<IReadOnlyCollection<FlightDto>> GetAllFlightsForPilotInDateRangeAsync(int pilotId, DateRangeParams dates)
        {
            var begin = DateTime.Parse(dates.BeginDate);
            var end = DateTime.Parse(dates.EndDate);

            var pilot = await _paraContext.Pilots
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ID == pilotId);

            if (pilot == null) return null;

            var flights = _paraContext.Flights
                .AsNoTracking()
                .Where(f => f.PilotID == pilotId &&
                            f.FlightDate >= begin &&
                            f.FlightDate <= end)
                .MapFlightCollection();

            return await flights.ToListAsync();
        }
    }
}
