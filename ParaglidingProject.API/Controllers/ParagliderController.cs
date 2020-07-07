using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using System.Text.Json;
using ParaglidingProject.SL.Core.Paraglider.NS;
using ParaglidingProject.SL.Core.Paraglider.NS.Helpers;
using ParaglidingProject.SL.Core.Paraglider.NS.TransfertObjects;
using ParaglidingProject.SL.Core.Flights.NS;
using Microsoft.AspNetCore.JsonPatch;

namespace ParaglidingProject.API.Controllers
{
    /// <summary>
    /// the controller of paraglider
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(GroupName = "paragliders")]
    [Produces("application/json")]
    [Route("api/v1/paragliders/")]


    public class ParagliderController : ControllerBase
    {
        private readonly IParagliderService _paragliderService;
        private readonly IFlightsService _flightsService;

       
        public ParagliderController(IParagliderService paragliderService, IFlightsService flightsService)
        {
            _paragliderService = paragliderService ?? throw new ArgumentNullException(nameof(paragliderService));
            _flightsService = flightsService ?? throw new ArgumentNullException(nameof(flightsService));
        }


        /// <summary>
        /// get a paraglider by id
        /// </summary>
        /// <param name="paragliderId">The unique id of a paraglider</param>
        /// <returns>
        /// an actionresult of type 202 who contain a paragliderDto
        /// an actionresult of type 404 if no paraglider was find
        /// <seealso cref="ParagliderDto"/>
        /// </returns>
        /// <remarks></remarks>
        [HttpGet("{paragliderId}", Name = "GetParagliderAsync")]

        public async Task<ActionResult<ParagliderAndFlightsDto>> GetParagliderAsync([FromRoute] int paragliderId)
        {
            ParagliderAndFlightsDto paragliderAndFlightsDto = new ParagliderAndFlightsDto();

            var paraglider = await _paragliderService.GetParagliderAsync(paragliderId);
            if (paraglider == null) return NotFound("Couldn't find any associated Paraglider");
            var flights = await _flightsService.GetFlightsByParaglider(paragliderId);
            if (flights == null) return NotFound("there is no flights for this paraglider");

            paragliderAndFlightsDto.ParagliderDto = paraglider;
            paragliderAndFlightsDto.FlightsDto = flights;
            return Ok(paragliderAndFlightsDto);
        }

        /// <summary>
        /// get all paraglider
        /// </summary>
        /// <param name="options">User options to search, sort, filter and paginate a list of paragliders obtained from a query strings.</param>
        /// <returns>
        /// an actionresult of type 202 who contain a list of paragliderDto
        /// an actionresult of type 404 if no paraglider was find
        /// <seealso cref="ParagliderDto"/>
        /// </returns>
        [HttpGet("", Name = "GetAllParaglidersAsync")]
     
        public async Task<ActionResult<IReadOnlyCollection<ParagliderDto>>> GetAllParaglidersAsync([FromQuery] ParaglidersSSFP options)
        {

            var paraglider = await _paragliderService.GetAllParaglidersAsync(options);
            if (paraglider == null) return NotFound("There is no paraglider ");

            var previousPageLink = options.HasPrevious ? CreateResourceUri(options, ResourceUriType.PreviousPage) : null;
            var nextPageLink = options.HasNext ? CreateResourceUri(options, ResourceUriType.NextPage) : null;

            var paginationMetadata = new
            {
                options.TotalCount,
                
                options.PageSize,
                options.PageNumber,
                options.TotalPages,
                options.SearchBy,
                options.DateLastRevision,
                options.Name,
                previousPageLink,
                nextPageLink
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(paraglider);
        }

        [HttpPost]
        public async Task<ActionResult<ParagliderDto>> CreateParaglider([FromBody] ParagliderDto pParagliderDto)
        {
            _paragliderService.CreateParaglider(pParagliderDto);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult<ParagliderDto>> EditParaglider([FromBody] ParagliderDto pParagliderDto)
        {
            _paragliderService.EditParaglider(pParagliderDto);
            return Ok();
        }
        [HttpDelete("{pParagliderDtoId}")]
        public async Task<ActionResult<ParagliderDto>> DeleteParaglider([FromRoute] int pParagliderDtoId)
        {
            _paragliderService.DeleteParaglider(pParagliderDtoId);
            return Ok();
        }

        [HttpPatch("{paragliderId}", Name = "PatchPilotAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult> PatchParagliderAsync([FromRoute] int paragliderId, [FromBody] JsonPatchDocument<ParagliderPatchDto> patchDocument)
        {
            var paragliderToPatch = await _paragliderService.GetParagliderToPatchAsync(paragliderId);
            if (paragliderToPatch == null) return NotFound("No paraglider found");

            patchDocument.ApplyTo(paragliderToPatch, ModelState);
            if (!TryValidateModel(paragliderToPatch)) return ValidationProblem(ModelState);

            var valuesMakeSense = paragliderToPatch.ValidateBusinessLogic();
            if (valuesMakeSense == false) return ValidationProblem("One or more values are forbidden");

            var patchSuccess = await _paragliderService.UpdateParagliderAsync(paragliderId, paragliderToPatch);
            return patchSuccess == true ? NoContent() : StatusCode(StatusCodes.Status503ServiceUnavailable);
        }


        /// <summary>
        /// Refactoring method that, given user parameters, creates a custom URL link to the previous and next page.
        /// </summary>
        /// <param name="options">The user custom options or default options for the search, sort, filter and pagination features.</param>
        /// <param name="type">One element of the enumeration to distinguish the multiple types of URLs to create.</param>
        /// <returns>
        /// A string that contains an URL link to the previous, the next page, or the current page by default.
        /// </returns>
        private string CreateResourceUri(ParaglidersSSFP options, ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link("GetAllParaglidersAsync",
                        new
                        {
                            PageNumber = options.PageNumber = -1,
                            options.PageSize,
                            options.SearchBy,
                            options.FilterBy,
                            options.SortBy,
                            options.LastRevisionDate,
                            options.Name
                            
                            
                        });
                case ResourceUriType.NextPage:
                    return Url.Link("GetAllParaglidersAsync",
                        new
                        {
                            PageNumber = options.PageNumber + 1,
                            options.PageSize,
                            options.SearchBy,
                            options.FilterBy,
                            options.SortBy,
                            options.LastRevisionDate,
                            options.Name
                        });
                default:
                    return Url.Link("GetAllParaglidersAsync",
                        new
                        {
                            options.PageNumber,
                            options.PageSize,
                            options.FilterBy,
                            options.SortBy,
                            options.SearchBy,
                            options.LastRevisionDate,
                            options.Name
                        });
            }
        }

         enum ResourceUriType
        {
            PreviousPage = 0,
            NextPage = 1
        }
    }
}