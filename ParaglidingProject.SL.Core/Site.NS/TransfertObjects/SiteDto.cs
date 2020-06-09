﻿using ParaglidingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.SL.Core.Site.NS.TransfertObjects
{
    public enum typesite
    {
        Takeoff,
        Landing
    }
    public class SiteDto
    {
        public int SiteId { get; set; }
        public string Name { get; set; }
        public string Orientation { get; set; }
        public int AltitudeTakeOff { get; set; }
        public string ApproachManeuver { get; set; }
        public string SiteGeoCoordinate { get; set; }
        public int NumberOfUse { get; set; }
        public int SiteType { get; set; }
        public typesite SiteName { get; set; }
        public Level Level { get; set; }
        

    }
}
