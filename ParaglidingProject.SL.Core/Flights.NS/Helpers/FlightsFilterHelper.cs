using ParaglidingProject.Models;
using System;
using System.Linq;

namespace ParaglidingProject.SL.Core.Flights.NS.Helpers
{
    public static class FlightsFilterHelper
    {
        /// <summary>
        /// A static method that filters a query of flights given by the user.
        /// </summary>
        /// <param name="flights">A query of flights to filter.</param>
        /// <param name="filterBy">One of the filters available in a list (enum) of possibilities.</param>
        /// <param name="takeOffSiteId">An integer that represents the identifier of a take-off site supplied by the user.</param>
        /// <param name="landingSiteId">An integer that represents the identifier of a landing site supplied by the user.</param>
        /// <returns>
        /// A custom-filtered query respecting the user's requests if the filters exist.
        /// An exception if a filter does not exist.
        /// </returns>
        public static IQueryable<Flight> FilterFlightBy(this IQueryable<Flight> flights, FlightsFilters filterBy, int? takeOffSiteId = null, int? landingSiteId = null,int pParagliderId = 0)
        {
            switch (filterBy)
            {
                case FlightsFilters.NoFilter:
                    return flights;

                case FlightsFilters.TakeOffSite:
                    return flights
                         .Where(f => f.TakeOffSiteID == takeOffSiteId);

                case FlightsFilters.LandingSite:
                    return flights
                        .Where(f => f.LandingSiteID == landingSiteId);
                case FlightsFilters.ParagliderId:
                    return flights.Where(f => f.ParagliderID == pParagliderId);
                default:
                    throw new ArgumentOutOfRangeException
                        (nameof(filterBy), filterBy, null);
            }
        }
    }
    public enum FlightsFilters
    {
        NoFilter = 0,
        TakeOffSite = 1,
        LandingSite = 2,
        ParagliderId = 3
    }
}
