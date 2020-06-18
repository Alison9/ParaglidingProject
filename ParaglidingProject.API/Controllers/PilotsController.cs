using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParaglidingProject.SL.Core.Pilot.NS;
using ParaglidingProject.SL.Core.Pilot.NS.Helpers;
using ParaglidingProject.SL.Core.Pilot.NS.TransfertObjects;

namespace ParaglidingProject.API.Controllers
{
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