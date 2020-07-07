using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("landing")]
        public async Task<ActionResult<IReadOnlyCollection<LandingDto>>> GetAllLandingAsync()
        {
            var landings = await _sitesService.GetAllLandingAsync();
            if (landings == null) return NotFound("Collection was empty");
            return Ok(landings);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("Takeoff")]
        public async Task<ActionResult<IReadOnlyCollection<TakeoffDto>>> GetAllTakeoffAsync()
        {
            var takeoff = await _sitesService.GetAllTakeOffAsync();
            if (takeoff == null) return NotFound("Collection was empty");
            return Ok(takeoff);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSiteDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<SiteDto>> CreateSite(SiteDto pSiteDto)
        {
            _sitesService.CreateSite(pSiteDto);
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pSiteDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<SiteDto>> EditSite(SiteDto pSiteDto)
        {
            _sitesService.EditSite(pSiteDto);
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<SiteDto>> Deletesite(int id)
        {
            _sitesService.DeleteSite(id);
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDocument"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPatch("{id}", Name = "PatchSiteAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult> PatchSiteAsync([FromRoute] int id, [FromBody] JsonPatchDocument<SitePatchDto> patchDocument)
        {
            var siteToPatch = await _sitesService.GetSiteToPatchAsync(id);
            if (siteToPatch == null) return NotFound("Site does not exist");

            patchDocument.ApplyTo(siteToPatch, ModelState);
            if (!TryValidateModel(siteToPatch)) return ValidationProblem(ModelState);

            var patchSuccess = await _sitesService.UpdateSiteAsync(id, siteToPatch);
            return patchSuccess == true ? NoContent() : StatusCode(StatusCodes.Status503ServiceUnavailable);
        }
    }
}
