using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.Licenses.NS.Helpers
{ 
    public enum LicencesFilter
    {

        NoFilter=0,
        Title=1, 
        licenseId=2

    }
    public static class LicencesFilterHelper
    {
        public static IQueryable<Models.License>FilterLicenseBy(this IQueryable<Models.License> licenses, LicencesFilter filterBy,int licenseid,string ltitle)
        {
            switch (filterBy)
            {
                case LicencesFilter.NoFilter:
                    return licenses;

                case LicencesFilter.Title:
                    return licenses
                        .Where(l => l.Title.Contains(ltitle));

                case LicencesFilter.licenseId:

                    return licenses.Where(l => l.LevelID == licenseid);
                  
               
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

}
