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
                .SearchSitesBy(options.SearchBy,options.SiteApproach,options.SiteName)
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

        public void CreateSite(SiteDto pSiteDto)
        {
            _paraContext.Sites.Add(new Models.Site
            {
                Name = pSiteDto.Name,
                Orientation = pSiteDto.Orientation,
                AltitudeTakeOff = pSiteDto.AltitudeTakeOff,
                SiteType = (Enm_SiteType)(int)pSiteDto.SiteType,
                SiteGeoCoordinate = pSiteDto.SiteGeoCoordinate,
                ApproachManeuver = pSiteDto.ApproachManeuver,
                LevelID = pSiteDto.Level.ID,
                IsActive = true
            }) ;
            _paraContext.SaveChanges();
        }
        public void EditSite(SiteDto pSiteDto)
        {
            var toModifyAsSite = _paraContext.Sites.Select(s => s).Where(s => s.ID == pSiteDto.SiteId).FirstOrDefault();

            toModifyAsSite.Name = pSiteDto.Name;
            toModifyAsSite.Orientation = pSiteDto.Orientation;
            toModifyAsSite.AltitudeTakeOff = pSiteDto.AltitudeTakeOff;
            toModifyAsSite.SiteType = (Enm_SiteType)(int)pSiteDto.SiteType;
            toModifyAsSite.ApproachManeuver = pSiteDto.ApproachManeuver;
            toModifyAsSite.LevelID = pSiteDto.Level.ID;
            toModifyAsSite.SiteGeoCoordinate = pSiteDto.SiteGeoCoordinate;

            _paraContext.Sites.Update(toModifyAsSite);
            _paraContext.SaveChanges();
        }
        public void DeleteSite(int id)
        {
            var toDelete = _paraContext.Sites.Select(s => s).Where(s => s.ID == id).FirstOrDefault();

            toDelete.IsActive = false;
            _paraContext.Sites.Update(toDelete);
            _paraContext.SaveChanges();
        }

        public async Task<SitePatchDto> GetSiteToPatchAsync(int id)
        {
            SitePatchDto site = await _paraContext.Sites
                .Where(s => s.ID == id)
                .Select(s => new SitePatchDto
                {
                    Name = s.Name,
                    Orientation = s.Orientation,
                    SiteGeoCoordinate = s.SiteGeoCoordinate
                })
                .FirstOrDefaultAsync();

            return site;
        }

        public async Task<bool?> UpdateSiteAsync(int id, SitePatchDto patchDto)
        {
            var siteToUpdate = await _paraContext.Sites
                .FirstOrDefaultAsync(p => p.ID == id);

            if (siteToUpdate == null) return null;

            siteToUpdate.Name = patchDto.Name;
            siteToUpdate.Orientation = patchDto.Orientation;
            siteToUpdate.SiteGeoCoordinate = patchDto.SiteGeoCoordinate;

            return await _paraContext.SaveChangesAsync() > 0;
        }
    }
}
