using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.Possession.NS.Helpers
{
  
    public enum PossessionsFilters
    {
      NoFilter = 0,
      NoPilot = 1,
      AtLeastOnePilot = 2
    }

    public static class PossessionFilterHelper
    {
      public static IQueryable<Models.Possession> FilterPossessionBy(this IQueryable<Models.Possession> possessions, PossessionsFilters filterBy)
      {
        switch (filterBy)
        {
          case PossessionsFilters.NoFilter:
            return possessions;


          default:
            throw new ArgumentOutOfRangeException
                (nameof(filterBy), filterBy, null);
        }
      }
    }
}
