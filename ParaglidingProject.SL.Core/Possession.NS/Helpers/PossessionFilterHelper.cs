using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.Possession.NS.Helpers
{
  
    public enum PossessionsFilters
    {
      
        NoFilter = 0,
        year = 1,
        LevelOfPilot = 2,

    }

    public static class PossessionFilterHelper
    {
      public static IQueryable<Models.Possession> FilterPossessionBy(this IQueryable<Models.Possession> possessions,PossessionSSFP options)
      {
        switch (options.FilterBy)
        {
          case PossessionsFilters.NoFilter:
            return possessions;

         case PossessionsFilters.year:
            return possessions
            .Where(pP => pP.ExamDate.Year == options.PossessionYear);

         case PossessionsFilters.LevelOfPilot:
                    return possessions
                    .Where(p => p.License.Level.DifficultyIndex == options.LevelOfPilot) ;




                default:
            throw new ArgumentOutOfRangeException
                (nameof(options.FilterBy), options.FilterBy, null);
        }
      }
    }
}
