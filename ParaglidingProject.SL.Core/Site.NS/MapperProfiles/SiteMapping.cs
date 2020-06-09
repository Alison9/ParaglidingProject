using ParaglidingProject.SL.Core.Site.NS.TransfertObjects;
using System.Linq;

namespace ParaglidingProject.SL.Core.Site.NS.MapperProfiles
{
    public static class SiteMapping
    {
        public static IQueryable<SiteDto> MapSiteDto(this IQueryable<Models.Site> Site)
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
