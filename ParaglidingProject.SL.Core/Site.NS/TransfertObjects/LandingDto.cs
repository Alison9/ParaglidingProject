using ParaglidingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.SL.Core.Site.NS.TransfertObjects
{
    public class LandingDto
    {
        public int SiteId { get; set; }
        public string Name { get; set; }
        public string Orientation { get; set; }
        public string ApproachManeuver { get; set; }
        public string SiteGeoCoordinate { get; set; }
        public int NumberOfUse { get; set; }
        public int SiteType { get; set; }
        public Level Level { get; set; }
    }
}
