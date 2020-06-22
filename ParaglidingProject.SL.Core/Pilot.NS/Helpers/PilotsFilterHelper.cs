using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ParaglidingProject.SL.Core.Pilot.NS.Helpers
{
    public enum PilotsFilters
    {
        NoFilter = 0,
        NoFlights = 1,
        AtLeastOneFlight = 2,
        License = 3
    }

    public static class PilotsFilterHelper
    {
        public static IQueryable<Models.Pilot> FilterPilotBy(this IQueryable<Models.Pilot> pilots, PilotsFilters filterBy, int licenseID = 0)
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

                case PilotsFilters.License:
                    return pilots
                        .Where(p => p.Possessions.Any(po => po.LicenseID == licenseID));
                       
                default:
                    throw new ArgumentOutOfRangeException
                        (nameof(filterBy), filterBy, null);
            }
        }
    }
}
