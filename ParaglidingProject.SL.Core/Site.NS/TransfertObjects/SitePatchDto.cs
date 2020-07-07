using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.SL.Core.Site.NS.TransfertObjects
{
    public class SitePatchDto
    {
        public string Name { get; set; }
        public string Orientation { get; set; }
        public string SiteGeoCoordinate { get; set; }

        public bool ValidateBusinessLogic()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Orientation) || string.IsNullOrWhiteSpace(SiteGeoCoordinate)) return false;
            return true;
        }
    }
}
