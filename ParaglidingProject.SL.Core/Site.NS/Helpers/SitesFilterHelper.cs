﻿using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.Site.NS.Helpers
{
    public enum SitesFilters
    {
        NoFilter = 0,
        NotActive = 1,
        Orientation = 2,
        Altitude = 3
    }
    public static class SitesFilterHelper
    {
        public static IQueryable<Models.Site> FilterSitesBy(this IQueryable<Models.Site> sites,SitesFilters filterBy, string pOrientation, int pAltitude)
        {
            switch (filterBy)
            {
                case SitesFilters.NoFilter:
                    return sites;
                case SitesFilters.NotActive:
                    return sites.Where(s => s.IsActive == false).IgnoreQueryFilters();
                case SitesFilters.Orientation:
                    return sites.Where(so => so.Orientation.Contains(pOrientation));
                case SitesFilters.Altitude:
                    return sites.Where(sa => sa.AltitudeTakeOff >= pAltitude);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
