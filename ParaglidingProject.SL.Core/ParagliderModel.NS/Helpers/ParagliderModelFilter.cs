using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.ParagliderModel.NS.Helpers
{

    public enum PargliderModelFilters
    {
        NoFilter = 0,
      heavyweight = 2,
        thinweight = 1,
        pilotweight=3
    }

    public static class ParagliderModelFilter
    {
        public static IQueryable<Models.ParagliderModel> FilterParagliderModelBy(this IQueryable<Models.ParagliderModel> paraglidermodels, PargliderModelFilters filterBy,int pilotweight)
        {
            switch (filterBy)
            {
                case PargliderModelFilters.NoFilter:
                    return paraglidermodels;

                case PargliderModelFilters.heavyweight:
                    return paraglidermodels
                        .Where(p => p.MaxWeightPilot<=250&& p.MaxWeightPilot>=100);
                    

                case PargliderModelFilters.thinweight:
                    return paraglidermodels
                        .Where(p => p.MinWeightPilot>=0 && p.MinWeightPilot<79);
                case PargliderModelFilters.pilotweight:
                    return paraglidermodels
                        .Where(p => p.MinWeightPilot <= pilotweight && p.MaxWeightPilot >= pilotweight);
                        
                default:
                    throw new ArgumentOutOfRangeException
                        (nameof(filterBy), filterBy, null);
            }
        }
    }
}

