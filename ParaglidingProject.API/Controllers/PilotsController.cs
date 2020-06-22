﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ParaglidingProject.SL.Core.Pilot.NS;
using ParaglidingProject.SL.Core.Pilot.NS.Helpers;
using ParaglidingProject.SL.Core.Pilot.NS.TransfertObjects;

namespace ParaglidingProject.API.Controllers
{
    [Authorize]
    [ApiController]
    [ApiExplorerSettings(GroupName = "pilots")]
    [Produces("application/json")]
    [Route("api/v1/pilots/")]
    public class PilotsController : ControllerBase
    {
        private readonly IPilotsService _pilotsService;

        public PilotsController(IPilotsService pilotsService)
        {
            _pilotsService = pilotsService ?? throw new ArgumentNullException(nameof(pilotsService)) ;
        }

        [AllowAnonymous]
        [HttpPatch("{pilotId}", Name = "PatchPilotAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult> PatchPilotAsync([FromRoute] int pilotId, [FromBody] JsonPatchDocument<PilotPatchDto> patchDocument)
        {
            var pilotToPatch = await _pilotsService.GetPilotToPatchAsync(pilotId);
            if (pilotToPatch == null) return NotFound("Pilot does not exists");

            patchDocument.ApplyTo(pilotToPatch, ModelState);
            if (!TryValidateModel(pilotToPatch)) return ValidationProblem(ModelState);

            //var valuesMakeSense = pilotToPatch.ValidateBusinessLogic();
            //if (valuesMakeSense == false) return ValidationProblem("One or more values are forbidden");

            var patchSuccess = await _pilotsService.UpdatePilotAsync(pilotId, pilotToPatch);
            return patchSuccess == true ? NoContent() : StatusCode(StatusCodes.Status503ServiceUnavailable);
        }

        //[Authorize(Roles = "Secretary")]
        [HttpGet("{pilotId}", Name = "GetPilotAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PilotDto>> GetPilotAsync([FromRoute] int pilotId)
        {
            var pilot = await _pilotsService.GetPilotAsync(pilotId);
            if (pilot == null) return NotFound("Couldn't find any associated Pilot");
            return Ok(pilot);
        }

        //[Authorize(Roles = "President")]
        [AllowAnonymous]
        [HttpGet("", Name = "GetAllPilotsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyCollection<PilotDto>>> GetAllPilotsAsync([FromQuery] SSFP options)
        {
            var pilots = await _pilotsService.GetAllPilotsAsync(options);
            if (pilots == null) return NotFound("Collection was empty :( ");

            var previousPageLink = options.HasPrevious ? CreateOrdersResourceUri(options, RessourceUriType.PreviousPage) : null;
            var nextPageLink = options.HasNext ? CreateOrdersResourceUri(options, RessourceUriType.NextPage) : null;

            var paginationMetadata = new
            {
                options.TotalCount,
                options.PageSize,
                options.PageNumber,
                options.TotalPages,
                previousPageLink,
                nextPageLink
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(pilots);
        }

        private string CreateOrdersResourceUri(SSFP options, RessourceUriType type)
        {
            switch (type)
            {
                case RessourceUriType.PreviousPage:
                    return Url.Link("GetAllPilotsAsync",
                        new
                        {
                            PageNumber = options.PageNumber - 1,
                            options.PageSize,
                            options.FilterBy
                        });

                case RessourceUriType.NextPage:
                    return Url.Link("GetAllPilotsAsync",
                        new
                        {
                            PageNumber = options.PageNumber + 1,
                            options.PageSize,
                            options.FilterBy
                        });

                default:
                    return Url.Link("GetAllPilotsAsync",
                        new
                        {
                            options.PageNumber,
                            options.PageSize,
                            options.FilterBy
                        });
            }
        }
    }

    public enum RessourceUriType
    {
        PreviousPage = 0,
        NextPage = 1
    }
}