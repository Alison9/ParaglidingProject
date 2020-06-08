using ParaglidingProject.SL.Core.Site.NS.TransfertObjects;
using System.Linq;

namespace ParaglidingProject.SL.Core.Site.NS.MapperProfiles
{
    public static class LandingMapping
    {
        public static IQueryable<LandingDto> MapLandingDto(this IQueryable<Models.Site> landing)
        {

            return landing.Select(s => new LandingDto
            {
                SiteId = s.ID,
                Name = s.Name,
                Orientation = s.Orientation,
                ApproachManeuver = s.ApproachManeuver,
                NumberOfUse = s.LandingFlights.Count + s.TakeOffFlights.Count,
                Level = s.Level
            }).Where(l => l.SiteType == 2);

        }
    }
}
