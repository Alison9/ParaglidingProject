using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ParaglidingProject.SL.Core.Flights.NS;
using ParaglidingProject.SL.Core.Flights.NS.Helpers;
using ParaglidingProject.SL.Core.Flights.NS.TransfertObjects;
using ParaglidingProject.SL.Core.Pilot.NS;

namespace ParaglidingProject.API.Controllers
{
    [ApiController]
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

        [HttpGet("{flightId}", Name = "GetFlightAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FlightDto>> GetFlightAsync([FromRoute] int flightId)
        {
            var flight = await _flightsService.GetFlightAsync(flightId);
            if (flight == null) return NotFound("No flight found");
            return Ok(flight);
        }

        [HttpGet("", Name ="GetAllFlightsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyCollection <FlightDto>>> GetAllFlightsAsync()
        {
            var flights = await _flightsService.GetAllFlightsAsync();
            if (flights == null) return NotFound("No flights found");
            return Ok(flights);
        }

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
    }
}