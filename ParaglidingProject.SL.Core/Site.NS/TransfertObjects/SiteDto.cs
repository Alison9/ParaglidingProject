using ParaglidingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static ParaglidingProject.Models.Enumeration;

namespace ParaglidingProject.SL.Core.Site.NS.TransfertObjects
{
    public class SiteDto
    {
        public int SiteId { get; set; }
        public string Name { get; set; }
        public string Orientation { get; set; }
        public int AltitudeTakeOff { get; set; }
        public string ApproachManeuver { get; set; }
        public string SiteGeoCoordinate { get; set; }
        public int NumberOfUse { get; set; }
        public Enm_SiteType SiteType { get; set; }
        public Level Level { get; set; }

    }
}
