using System;
using System.Linq;

namespace ParaglidingProject.SL.Core.Pilot.NS.Helpers
{
    public enum PilotsFilters
    {
        NoFilter = 0,
        NoFlights = 1,
        AtLeastOneFlight = 2
    }

    public static class PilotsFilterHelper
    {
        public static IQueryable<Models.Pilot> FilterPilotBy(this IQueryable<Models.Pilot> pilots, PilotsFilters filterBy)
        {
            switch (filterBy)
            {
                case PilotsFilters.NoFilter:
                    return pilots;

                case PilotsFilters.NoFlights:
                    return pilots
                        .Where(p => p.Flights.Count == 0);

                case PilotsFilters.AtLeastOneFlight:
                    return pilots
                        .Where(p => p.Flights.Count > 0);

                default:
                    throw new ArgumentOutOfRangeException
                        (nameof(filterBy), filterBy, null);
            }
        }
    }
}
