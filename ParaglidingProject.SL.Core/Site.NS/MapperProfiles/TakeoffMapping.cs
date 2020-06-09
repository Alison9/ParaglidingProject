using ParaglidingProject.SL.Core.Site.NS.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace ParaglidingProject.SL.Core.Site.NS.MapperProfiles
{
   public static  class TakeoffMapping
    {
        public static IQueryable<TakeoffDto> MapTakeoffCollection(this IQueryable<Models.Site> site)
        {
            return site.Select(t => new TakeoffDto
            {
                SiteId = t.ID,
                Name = t.Name,
                Orientation = t.Orientation,
                AltitudeTakeOff = t.AltitudeTakeOff,
                SiteGeoCoordinate = t.SiteGeoCoordinate,
                
                Level = t.Level

            }); 

        }
    }
}
