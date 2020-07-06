using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.ParagliderModel.NS.Helpers
{
    public enum ParagliderModelsSorts
    {
        NoSort = 0,
        Heavyweight = 2,
        Thinweight = 1,
        Pilotweight = 3
            
    }
    public static class ParagliderModelSortHelper
    {
        public static IQueryable<Models.ParagliderModel> ParagliderModelsSortsBy(this IQueryable<Models.ParagliderModel> paragliderModels, ParagliderModelsSorts sortBy)
        {
            switch (sortBy)
            {
                case ParagliderModelsSorts.NoSort:
                    return paragliderModels;
                case ParagliderModelsSorts.Heavyweight:
                    return paragliderModels
                        .OrderBy(pa => pa.MaxWeightPilot)
                        .ThenBy(pa => pa.Size);
                case ParagliderModelsSorts.Thinweight:
                    return paragliderModels.OrderByDescending(pa => pa.MinWeightPilot)
                        .ThenBy(pa => pa.Size);
                case ParagliderModelsSorts.Pilotweight:
                    return paragliderModels.OrderBy(pa => pa.MinWeightPilot & pa.MaxWeightPilot );
                default:
                    throw new ArgumentOutOfRangeException
                        (nameof(sortBy), sortBy, null);
            }
        }
    }
}
