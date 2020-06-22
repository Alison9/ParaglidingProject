using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ParaglidingProject.SL.Core.Site.NS;
using ParaglidingProject.SL.Core.Site.NS.Helpers;
using ParaglidingProject.SL.Core.Site.NS.TransfertObjects;

namespace ParaglidingProject.API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "sites")]
    [Produces("application/json")]
    [Route("api/v1/sites/")]
    public class SiteController : ControllerBase
    {
        private readonly ISitesService _sitesService;

        public SiteController(ISitesService sitesService)
        {
            _sitesService = sitesService ?? throw new ArgumentNullException(nameof(sitesService));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SiteDto>> GetSiteAsync([FromRoute] int id)
        {
            var site = await _sitesService.GetSiteAsync(id);
            if (site == null) return NotFound("Couldn't find any associated Site");
            return Ok(site);
        }
      
        [HttpGet("",Name = "GetAllSitesAsync")]
        public async Task<ActionResult<IReadOnlyCollection<SiteDto>>> GetAllSiteAsync([FromQuery] SiteSSFP options)
        {
            var sites = await _sitesService.GetAllSitesAsync(options);
            if (sites == null) return NotFound("Collection was empty");

            var previousPageLink = options.HasPrevious ? CreateResourceUri(options, ResourceUriType.PreviousPage) : null;
            var nextPageLink = options.HasNext ? CreateResourceUri(options, ResourceUriType.NextPage) : null;

            var paginationMetadata = new
            {
                options.TotalCount,
                options.PageSize,
                options.PageNumber,
                options.TotalPages,
                previousPageLink,
                nextPageLink
            };

            Response.Headers.Add("X-Pagination", System.Text.Json.JsonSerializer.Serialize(paginationMetadata));

            return Ok(sites);
        
        }
        private string CreateResourceUri(SiteSSFP options, ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link("GetAllParaglidersAsync",
                        new
                        {
                            PageNumber = options.PageNumber = 1,
                            options.PageSize,



                        });
                case ResourceUriType.NextPage:
                    return Url.Link("GetAllParaglidersAsync",
                        new
                        {
                            PageNumber = options.PageNumber + 1,
                            options.PageSize
                        });
                default:
                    return Url.Link("GetAllParaglidersAsync",
                        new
                        {
                            options.PageNumber,
                            options.PageSize
                        });
            }
        }

        enum ResourceUriType
        {
            PreviousPage = 0,
            NextPage = 1
        }

        [HttpGet("landing")]
        public async Task<ActionResult<IReadOnlyCollection<LandingDto>>> GetAllLandingAsync()
        {
            var landings = await _sitesService.GetAllLandingAsync();
            if (landings == null) return NotFound("Collection was empty");
            return Ok(landings);
        }
        [HttpGet("Takeoff")]
        public async Task<ActionResult<IReadOnlyCollection<TakeoffDto>>> GetAllTakeoffAsync()
        {
            var takeoff = await _sitesService.GetAllTakeOffAsync();
            if (takeoff == null) return NotFound("Collection was empty");
            return Ok(takeoff);
        }
    }
}
