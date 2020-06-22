using ParaglidingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.Flights.NS.Helpers
{
    public enum FlightsSorts
    {
        NoSort = 0,
        DateAscending = 1,
        DateDescending = 2,
        PilotLastNameAscending = 3,
        PilotFirstNameAscending = 4,
        DateAscendingThenPilotFirstNameAscending = 5
    }
    public static class FlightsSortHelper
    {
        /// <summary>
        /// A static method that sort a query of flights given by the user
        /// </summary>
        /// <param name="flights">A query of flights to sort</param>
        /// <param name="sortBy">A sortBy as a FlightsSorts (enum)</param>
        /// <returns>
        /// A sort query respecting the user's requests if the sort exist.
        /// An exception if the sort doesn't exist.
        /// </returns>
        public static IQueryable<Flight> SortFlightBy(this IQueryable<Flight> flights, FlightsSorts sortBy)
        {
            switch(sortBy)
            {
                case FlightsSorts.NoSort:
                    return flights;

                case FlightsSorts.DateAscending:
                    return flights.OrderBy(f => f.FlightDate);

                case FlightsSorts.DateDescending:
                    return flights.OrderByDescending(f => f.FlightDate);

                case FlightsSorts.PilotLastNameAscending:
                    return flights.OrderBy(f => f.Pilot.LastName);

                case FlightsSorts.PilotFirstNameAscending:
                    return flights.OrderBy(f => f.Pilot.FirstName);

                case FlightsSorts.DateAscendingThenPilotFirstNameAscending:
                    return flights.OrderBy(f => f.FlightDate).ThenBy(f => f.Pilot.FirstName);

                default:
                    throw new ArgumentOutOfRangeException
                        (nameof(sortBy), sortBy, null);
            }
        }
    }
}
