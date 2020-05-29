using ParaglidingProject.Models;
using ParaglidingProject.SL.Core.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.MapperProfiles
{
    public static class  SiteMapping
    {
        public static IQueryable<SiteDto> MapSiteDto(this IQueryable<Site> Site) 
        {

            return Site.Select(s => new SiteDto
            {
                SiteId = s.ID,
                Name = s.Name,
                Orientation = s.Orientation,
                AltitudeTakeOff = s.AltitudeTakeOff,
                ApproachManeuver = s.ApproachManeuver,
                NumberOfUse = s.LandingFlights.Count + s.TakeOffFlights.Count,
                SiteType = s.SiteType,
                Level = s.Level
            });

        }
    }
}
