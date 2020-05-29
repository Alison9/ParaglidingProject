using Microsoft.EntityFrameworkCore;
using ParaglidingProject.Data;
using ParaglidingProject.Models;
using ParaglidingProject.SL.Core.MapperProfiles;
using ParaglidingProject.SL.Core.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core
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
    }
}
