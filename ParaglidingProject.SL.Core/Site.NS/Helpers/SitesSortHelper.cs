using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.Site.NS.Helpers
{
    public enum SitesSorts
    {
        NoSort = 0,
        AltitudeTakeOff = 1,
        LevelRequired = 2,
        Name = 3
    }
    public static class SitesSortHelper
    {
        public static IQueryable<Models.Site> SortSitesBy(this IQueryable<Models.Site> sites, SitesSorts sortBy)
        {
            switch (sortBy)
            {
                case SitesSorts.NoSort:
                    return sites;
                case SitesSorts.AltitudeTakeOff:
                    return sites
                        .OrderBy(s => s.AltitudeTakeOff)
                        .ThenBy(s => s.Name);
                case SitesSorts.LevelRequired:
                    return sites.OrderByDescending(s => s.Level.DifficultyIndex).ThenBy(s => s.Name);
                case SitesSorts.Name:
                    return sites.OrderBy(s => s.Name);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
