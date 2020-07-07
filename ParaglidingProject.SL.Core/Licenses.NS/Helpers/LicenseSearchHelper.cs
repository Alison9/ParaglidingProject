using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.Licenses.NS.Helpers
{

    public enum LicensesSearch
    {
        NoSearch = 0,
        Title=1, 
        LevelId=2,
       
    }
    public static class LicenseSearchHelper
    {
        public static IQueryable<Models.License> SearchLicenseBy(this IQueryable<Models.License> license, LicensesSearch SearchBy, string namelicense, int numberlicense)
        {
            switch (SearchBy)
            {
                case LicensesSearch.NoSearch:
                    return license;

                case LicensesSearch.Title:
                    return license
                        .Where(l => l.Title.Contains(namelicense));
                case LicensesSearch.LevelId:
                    return license
                        .Where(l => l.LevelID == numberlicense);

                default:
                    throw new ArgumentOutOfRangeException
                        (nameof(SearchBy),SearchBy, null);

            }
        }
    }
}
