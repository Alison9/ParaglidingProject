using Microsoft.EntityFrameworkCore;
using ParaglidingProject.Data;
using ParaglidingProject.Models;
using ParaglidingProject.SL.Core.Site.NS.TransfertObjects;
using ParaglidingProject.SL.Core.Site.NS.MapperProfiles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using static ParaglidingProject.Models.Enumeration;

namespace ParaglidingProject.SL.Core.Site.NS
{
    public class SitesService : ISitesService
    {
        private readonly ParaglidingClubContext _paraContext;

        public SitesService(ParaglidingClubContext paracontext)
        {
            _paraContext = paracontext;
        }

        public async Task<IReadOnlyCollection<SiteDto>> GetAllSitesAsync()
        {
            var sites = _paraContext.Sites
                .AsNoTracking()
                .MapSiteDto();

            return await sites.ToListAsync();
        }

        

        public async Task<SiteDto> GetSiteAsync(int id)
        {
            var site = _paraContext.Sites
                .AsNoTracking()
                .MapSiteDto()
                .FirstOrDefaultAsync(s => s.SiteId == id);

            return await site;
        }
        public async Task<IReadOnlyCollection<LandingDto>> GetAllLandingAsync()
        {
            var landings = _paraContext.Sites
                .AsNoTracking()
                .Where(l => l.SiteType == Enm_SiteType.Landing)
                .MapLandingDto();

            return await landings.ToListAsync();
        }
        public async Task<IReadOnlyCollection<TakeoffDto>> GetAllTakeOffAsync()
        {

            var takeoff = _paraContext.Sites
                .AsNoTracking()
               .Where(s=>s.SiteType== Models.typesite.takeoff)
                .MapTakeoffCollection();

            return await takeoff.ToListAsync();
        }



    }
}
