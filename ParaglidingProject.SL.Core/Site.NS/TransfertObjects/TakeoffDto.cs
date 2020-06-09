using ParaglidingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.SL.Core.Site.NS.TransfertObjects
{
 

   public class TakeoffDto
    {
        public int SiteId { get; set; }
        public string Name { get; set; }
        public string Orientation { get; set; }
        public  int AltitudeTakeOff { get; set; }
       
        public string SiteGeoCoordinate { get; set; }
      
        public Level Level { get; set; }
    }
}
