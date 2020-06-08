using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParaglidingProject.SL.Core.Site.NS;
using ParaglidingProject.SL.Core.Site.NS.TransfertObjects;

namespace ParaglidingProject.API.Controllers
{
    [ApiController]
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
        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<SiteDto>>> GetAllSiteAsync()
        {
            var sites = await _sitesService.GetAllSitesAsync();
            if (sites == null) return NotFound("Collection was empty");
            return Ok(sites);
        }
        [HttpGet("landing")]
        public async Task<ActionResult<IReadOnlyCollection<LandingDto>>> GetAllLandingAsync()
        {
            var landing = await _sitesService.GetAllLandingAsync();
            if (landing == null) return NotFound("Collection was empty");
            return Ok(landing);
        }
    }
}
