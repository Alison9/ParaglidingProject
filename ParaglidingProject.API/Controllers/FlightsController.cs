using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParaglidingProject.SL.Core.Flights.NS;
using ParaglidingProject.SL.Core.Flights.NS.TransfertObjects;

namespace ParaglidingProject.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/flights/")]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightsService _flightsService;
        public FlightsController(IFlightsService flightsService)
        {
            _flightsService = flightsService ?? throw new ArgumentNullException(nameof(flightsService));
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


    }
}