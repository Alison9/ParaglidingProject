using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.Site.NS.Helpers
{
    public enum SitesSearchingBy
    {
        None = 0,
        ApproachManeuver = 1,
        Name = 2
    }
    public static class SitesSearchBy
    {
        public static IQueryable<Models.Site> SearchSitesBy (this IQueryable<Models.Site> sites, SitesSearchingBy searchBy,string pApproachManeuver = null,string pName = null)
        {
            switch (searchBy)
            {
                case SitesSearchingBy.None:
                    return sites;
                case SitesSearchingBy.ApproachManeuver:
                    return sites.Where(s => s.ApproachManeuver.Contains(pApproachManeuver));
                case SitesSearchingBy.Name:
                    return sites.Where(s => s.Name.Contains(pName));
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
