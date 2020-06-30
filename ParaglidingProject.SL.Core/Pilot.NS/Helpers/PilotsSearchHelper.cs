using ParaglidingProject.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.Pilot.NS.Helpers
{
    public enum PilotsSearches
    { 
        NoSearch = 0,
        FirstName = 1,
        LastName = 2,
        Address = 3,
        PhoneNumber = 4
    }
    public static class PilotsSearchHelper
    {
        public static IQueryable<Models.Pilot> SearchPilotBy(this IQueryable<Models.Pilot> pilots, PilotSSFP options)
        {
            switch (options.SearchBy)
            {
                case PilotsSearches.NoSearch:
                    return pilots;

                case PilotsSearches.FirstName:
                    return pilots
                        .Where(p => p.FirstName.Contains(options.UserInput));

                case PilotsSearches.LastName:
                    return pilots
                        .Where(p => p.LastName.Contains(options.UserInput));

                case PilotsSearches.Address:
                    return pilots
                        .Where(p => p.Address.Contains(options.UserInput));

                case PilotsSearches.PhoneNumber:
                    return pilots
                        .Where(p => p.PhoneNumber.Contains(options.UserInput));

                default:
                    throw new ArgumentOutOfRangeException
                        (nameof(options.SearchBy), options.SearchBy, null);
            }

        }
    }
}
