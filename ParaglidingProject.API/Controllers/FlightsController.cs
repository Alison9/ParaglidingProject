using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using ParaglidingProject.SL.Core.Flights.NS;
using ParaglidingProject.SL.Core.Flights.NS.Helpers;
using ParaglidingProject.SL.Core.Flights.NS.TransfertObjects;
using ParaglidingProject.SL.Core.Pilot.NS;

namespace ParaglidingProject.API.Controllers
{
    /// <summary>
    /// Flights Controller
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(GroupName = "flights")]
    [Produces("application/json")]
    [Route("api/v1/flights/")]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightsService _flightsService;
        private readonly IPilotsService _pilotsService;

        public FlightsController(IFlightsService flightsService, IPilotsService pilotsService)
        {
            _flightsService = flightsService ?? throw new ArgumentNullException(nameof(flightsService));
            _pilotsService = pilotsService ?? throw new ArgumentNullException(nameof(pilotsService));
        }

        /// <summary>
        /// Get a Flight
        /// </summary>
        /// <param name="flightId">flightId as an integer</param>
        /// <returns>An ActionResult of type 200 response who contains a FlightDto.
        /// An ActionResult of type 404 if no flight was found.
        /// <seealso cref="FlightDto"/>
        /// </returns>
        [HttpGet("{flightId}", Name = "GetFlightAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FlightDto>> GetFlightAsync([FromRoute] int flightId)
        {
            var flight = await _flightsService.GetFlightAsync(flightId);
            if (flight == null) return NotFound("No flight found");
            return Ok(flight);
        }

        /// <summary>
        /// Get all Flights
        /// </summary>
        /// <param name="options">It contains all the paramameters used to filter, page , search and sort the list of flights</param>
        /// <returns>An ActionResult of type 200 response who contains a IReadOnlyCollection of FlightDto.
        /// An ActionResult of type 404 if no flight was found.
        /// <seealso cref="FlightDto"/>
        /// </returns>
        [HttpGet("", Name ="GetAllFlightsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyCollection <FlightDto>>> GetAllFlightsAsync([FromQuery] FlightsSSFP options)
        {
            var flights = await _flightsService.GetAllFlightsAsync(options);
            if (flights == null) return NotFound("No flights found");

            var previousPageLink = options.HasPrevious ? CreateResourceUri(options, ResourceUriType.PreviousPage) : null;
            var nextPageLink = options.HasNext ? CreateResourceUri(options, ResourceUriType.NextPage) : null;

            var paginationMetadata = new
            {
                options.TotalCount,
                options.PageSize,
                options.PageNumber,
                options.TotalPages,
                options.SortBy,
                previousPageLink,
                nextPageLink
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(flights);
        }

        /// <summary>
        /// Get all Flights for a Pilot in a date range 
        /// </summary>
        /// <param name="pilotId">pilotId as an integer</param>
        /// <param name="dates">dates as DateRangeParams</param>
        /// <returns>An ActionResult of type 200 response who contains a IReadOnlyCollection of FlightDto.
        /// An ActionResult of type 404 if no flight was found.
        /// An ActionResult of type 404 if no flight was found in de range of date.
        /// <seealso cref="FlightDto"/>
        /// </returns>
        [HttpGet("pilote/{pilotId}", Name = "GetAllFlightsForPilotInDateRangeAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyCollection<FlightDto>>> GetAllFlightsForPilotInDateRangeAsync(
            [FromRoute] int pilotId, [FromBody] DateRangeParams dates)
        {
            var validateDate = dates.ValidateDate();
            if (!validateDate) return NotFound("Cannot validate date");

            var pilot = await _pilotsService.GetPilotAsync(pilotId);
            if (pilot == null) return NotFound("Couldn't find any associated Pilot");

            var flights = await _flightsService.GetAllFlightsForPilotInDateRangeAsync(pilotId, dates);
            if (flights == null || flights.Count == 0) return NotFound("Oops, empty collection");

            return Ok(flights);
        }

        private string CreateResourceUri(FlightsSSFP options, ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link("GetAllFlightssAsync",
                        new
                        {
                            PageNumber = options.PageNumber = 1,
                            options.PageSize,
                            options.FilterBy,
                            options.SortBy
                        });
                case ResourceUriType.NextPage:
                    return Url.Link("GetAllFlightsAsync",
                        new
                        {
                            PageNumber = options.PageNumber + 1,
                            options.PageSize,
                            options.FilterBy,
                            options.SortBy
                        });
                default:
                    return Url.Link("GetAllFlightsAsync",
                        new
                        {
                            options.PageNumber,
                            options.PageSize,
                            options.FilterBy,
                            options.SortBy
                        }) ;
            }
        }

        public enum ResourceUriType
        {
            PreviousPage = 0,
            NextPage = 1
        }
    }
}