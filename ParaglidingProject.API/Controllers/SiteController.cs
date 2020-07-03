using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ParaglidingProject.SL.Core.Flights.NS;
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
        private readonly IFlightsService _flightService;

        public SiteController(ISitesService sitesService,IFlightsService flightsService)
        {
            _sitesService = sitesService ?? throw new ArgumentNullException(nameof(sitesService));
            _flightService = flightsService ?? throw new ArgumentNullException(nameof(flightsService));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SiteAndFlightsDto>> GetSiteAsync([FromRoute] int id)
        {
            SiteAndFlightsDto siteAndFlightsDto = new SiteAndFlightsDto();

            var site = await _sitesService.GetSiteAsync(id);
            if (site == null) return NotFound("Couldn't find any associated Site");
            var flights = await _flightService.GetFlightsBySite(id);
            if (flights == null) return NotFound("Couldn't find any associated flight");

            siteAndFlightsDto.SiteDto = site;
            siteAndFlightsDto.FlightsDto = flights;

            return Ok(siteAndFlightsDto);
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
        [HttpPost]
        public async Task<ActionResult<SiteDto>> CreateSite(SiteDto pSiteDto)
        {
            _sitesService.CreateSite(pSiteDto);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult<SiteDto>> EditSite(SiteDto pSiteDto)
        {
            _sitesService.EditSite(pSiteDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<SiteDto>> Deletesite(int id)
        {
            _sitesService.DeleteSite(id);
            return Ok();
        }
    }
}
