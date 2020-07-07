using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.Licenses.NS.Helpers
{

    public enum LicenseSorts
    {
        NoSort = 0,
        LicenseId=1,
        Title=2,
        LevelDifficultyIndex=3


    }
    public static class LicenceSortHelper
    {
        public static IQueryable<Models.License> SortLicenseBy(this IQueryable<Models.License> licenses, LicenseSorts sortBy)
        {
            switch (sortBy)
            {
                case LicenseSorts.NoSort:
                    return licenses;

                case LicenseSorts.LicenseId:
                    return licenses
                        .OrderBy(l => l.ID);
                      
                case LicenseSorts.Title:
                    return licenses
                        .OrderBy(l => l.Title);

                case LicenseSorts.LevelDifficultyIndex:
                    return licenses
                        .OrderBy(l => l.LevelID);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
