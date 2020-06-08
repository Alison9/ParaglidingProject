using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public PossessionsController(IPossessionsService possessionsService)
        {
            _possessionsService = possessionsService ?? throw new ArgumentNullException(nameof(possessionsService));
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
        [HttpGet("{pilotId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyCollection<PossessionDto>>> GetPossessionByPilotAsync([FromRoute] int pilotId)
        {
            var possessions = await _possessionsService.GetPossessionByPilotAsync(pilotId);
            if (possessions == null) return NotFound($"Couldn't find any associated Possession for Pilot {pilotId}");
            return Ok(possessions);
        }
    }

}
