using System;
using System.Linq;

namespace ParaglidingProject.SL.Core.Pilot.NS.Helpers
{
    public enum PilotsSorts
    {
        NoSort = 0,
        FirstName = 1,
        LastName = 2,
        Weight = 3,
        NumberOfFlights = 4,
        SubscriptionPayments = 5
    }
    public static class PilotsSortHelper
    {
        /// <summary>
        /// A static method that returns a sorted query of pilots by the choice of the user.
        /// </summary>
        /// <param name="pilots">The base query from the database.</param>
        /// <param name="sortBy">The parameter chosen by then user.</param>
        /// <returns>
        /// A sorted query of pilots.
        /// </returns>
        public static IQueryable<Models.Pilot> SortPilotsBy(this IQueryable<Models.Pilot> pilots, PilotsSorts sortBy)
        {
            switch (sortBy)
            {
                case PilotsSorts.NoSort:
                    return pilots;

                case PilotsSorts.FirstName:
                    return pilots
                        .OrderBy(p => p.FirstName)
                        .ThenBy(p => p.LastName);

                case PilotsSorts.LastName:
                    return pilots
                        .OrderBy(p => p.LastName)
                        .ThenBy(p => p.FirstName);

                case PilotsSorts.Weight:
                    return pilots
                        .OrderBy(p => p.Weight)
                        .ThenBy(p => p.LastName)
                        .ThenBy(p => p.FirstName);

                case PilotsSorts.NumberOfFlights:
                    return pilots
                        .OrderBy(p => p.Flights.Count)
                        .ThenBy(p => p.LastName);

                case PilotsSorts.SubscriptionPayments:
                    return pilots
                        .OrderBy(p => p.SubscriptionsPayments.Count)
                        .ThenBy(p => p.LastName);

                default:
                    throw new ArgumentOutOfRangeException
                        (nameof(sortBy), sortBy, null);
            }
        }
    }
}
