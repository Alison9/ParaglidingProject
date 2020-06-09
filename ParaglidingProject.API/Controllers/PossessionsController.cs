using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParaglidingProject.SL.Core.Pilot.NS;
using ParaglidingProject.SL.Core.Possession.NS;
using ParaglidingProject.SL.Core.Possession.NS.TransferObjects;

namespace ParaglidingProject.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/possessions/")]
    public class PossessionsController : ControllerBase
    {
        private readonly IPossessionsService _possessionsService;
        private readonly IPilotsService _PilotService;

        public PossessionsController(IPossessionsService possessionsService, IPilotsService pilotsService)
        {
            _possessionsService = possessionsService ?? throw new ArgumentNullException(nameof(possessionsService));
            _PilotService = pilotsService ?? throw new ArgumentNullException(nameof(pilotsService));
        }

        [HttpPost("", Name = "GetPossessionAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PossessionDto>> GetPossessionAsync([FromQuery] int Pilotid, [FromQuery]int Licenseid)
        {
            var possession = await _possessionsService.GetPossessionAsync(Pilotid, Licenseid);
            if (possession == null) return NotFound("Couldn't find any associated Possession");
            return Ok(possession);
        }
        [HttpGet("", Name = "GetAllPossessionsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyCollection<PossessionDto>>> GetAllPossessionsAsync()
        {
            var possessions = await _possessionsService.GetAllPossessionsAsync();
            if (possessions == null) return NotFound("Collection was empty");
            return Ok(possessions);
        }
        [HttpGet("pilot/{pilotId}", Name = "GetPossessionByPilotAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyCollection<PossessionDto>>> GetPossessionByPilotAsync([FromRoute] int pilotId)
        {
            var pilot = await _PilotService.GetPilotAsync(pilotId);
            if (pilot == null) return NotFound("Couldn't find any Pilot");

            var possessions = await _possessionsService.GetPossessionByPilotAsync(pilotId);
            if (possessions == null || possessions.Count == 0) return NotFound("Couldn't find any Possession for Pilot");
            return Ok(possessions);
        }
    }

}
