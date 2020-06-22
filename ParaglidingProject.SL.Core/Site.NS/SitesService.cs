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
using ParaglidingProject.SL.Core.Site.NS.Helpers;
using ParaglidingProject.SL.Core.Helpers;
using System.Collections.Immutable;

namespace ParaglidingProject.SL.Core.Site.NS
{
    /// <inheritdoc />
    public class SitesService : ISitesService
    {
        private readonly ParaglidingClubContext _paraContext;

        public SitesService(ParaglidingClubContext paracontext)
        {
            _paraContext = paracontext;
        }

        public async Task<IReadOnlyCollection<SiteDto>> GetAllSitesAsync(SiteSSFP options)
        {
            var sites = _paraContext.Sites
                .AsNoTracking()
                .SortSitesBy(options.SortBy)
                .FilterSitesBy(options.FilterBy, options.Orientation, options.AltitudeTakeOff)
                .MapSiteDto();

            options.SetPagingValues(sites);

            var pagedQuery = sites.Page(options.PageNumber - 1, options.PageSize);

            return await pagedQuery.ToListAsync();
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
               .Where(s=>s.SiteType== Enm_SiteType.TakeOff)
                .MapTakeoffCollection();

            return await takeoff.ToListAsync();
        }



    }
}
