using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.SL.Core.Licenses.NS.Helpers
{
    public class LicenseSSFP
    {
        //sort properties
        public LicenseSorts SortBy { get; set; }
        //Filter  properties
        public LicencesFilter FilterBy { get; set; }
       
         
        //Search  properties

        public LicensesSearch SearchBy { get; set; }
        public int NumberLicence { get; set; }
        public string NameLicense { get; set; }



    }
}
