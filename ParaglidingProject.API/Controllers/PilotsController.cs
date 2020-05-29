﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParaglidingProject.SL.Core;
using ParaglidingProject.SL.Core.TransfertObjects;

namespace ParaglidingProject.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/pilots/")]
    public class PilotsController : ControllerBase
    {
        private readonly IPilotsService _pilotsService;

        public PilotsController(IPilotsService pilotsService)
        {
            _pilotsService = pilotsService ?? throw new ArgumentNullException(nameof(pilotsService)) ;
        }

        [HttpGet("{pilotId}", Name = "GetPilotAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PilotDto>> GetPilotAsync([FromRoute] int pilotId)
        {
            var pilot = await _pilotsService.GetPilotAsync(pilotId);
            if (pilot == null) return NotFound("Couldn't find any associated Pilot");
            return Ok(pilot);
        }

        [HttpGet("", Name = "GetAllPilotsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyCollection<PilotDto>>> GetAllPilotsAsync()
        {
            var pilots = await _pilotsService.GetAllPilotsAsync();
            if (pilots == null) return NotFound("Collection was empty :( ");
            return Ok(pilots);
        }
    }
}