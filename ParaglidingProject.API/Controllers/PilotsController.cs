using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ParaglidingProject.Models;
using ParaglidingProject.SL.Core.Licenses.NS;
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
        private readonly ILicensesService _licensesService;
      

        public PilotsController(IPilotsService pilotsService, ILicensesService licensesService)
        {
            _pilotsService = pilotsService ?? throw new ArgumentNullException(nameof(pilotsService));
            _licensesService = licensesService ?? throw new ArgumentNullException(nameof(licensesService));
        }

        //[Authorize(Roles = "Secretary")]
        [AllowAnonymous]
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
        public async Task<ActionResult<IReadOnlyCollection<PilotDto>>> GetAllPilotsAsync([FromQuery] PilotSSFP options)
        {
            var pilots = await _pilotsService.GetAllPilotsAsync(options);
            if (pilots == null) return NotFound("Collection was empty :( ");

            if((int)options.FilterBy == 3)
            {
                var license = await _licensesService.GetLicenseAsync(options.LicenseID);
                if (license == null) return NotFound("License not valid");
            };

            var previousPageLink = options.HasPrevious ? CreateResourceUri(options, RessourceUriType.PreviousPage) : null;
            var nextPageLink = options.HasNext ? CreateResourceUri(options, RessourceUriType.NextPage) : null;

            var paginationMetadata = new
            {
                options.TotalCount,
                options.PageSize,
                options.PageNumber,
                options.TotalPages,
                options.SortBy,
                options.FilterBy,
                options.SearchBy,
                options.LicenseID,
                previousPageLink,
                nextPageLink
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(pilots);
        }

        //[Authorize(Roles = "President")]
        [AllowAnonymous]
        [HttpPost("", Name ="PostPilotAsync")]
        public async Task<ActionResult<Pilot>> PostPilotAsync([FromBody] Pilot pilot)
        {
            await _pilotsService.PostPilotAsync(pilot);
            return Ok(pilot);
        }

        //[Authorize(Roles = "President")]
        [AllowAnonymous]
        [HttpPut("{id}", Name = "UpdatePilotAsync")]
        public async Task<ActionResult<Pilot>> UpdatePilotAsync([FromRoute] int id, [FromBody] Pilot pilot)
        {
            if (pilot == null)
            {
                return BadRequest();
            }

            pilot.ID = id;
            await _pilotsService.UpdatePilotAsync(pilot);

            return Ok(pilot);
        }

        //[Authorize(Roles = "President")]
        [AllowAnonymous]
        [HttpDelete("{id}", Name = "DeletePilotAsync")]
        public async Task<ActionResult<Pilot>> DeletePilotAsync([FromRoute] int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            await _pilotsService.DeletePilotAsync(id);
            return Ok("Delete succeeded.");
        }


        private string CreateResourceUri(PilotSSFP options, RessourceUriType type)
        {
            switch (type)
            {
                case RessourceUriType.PreviousPage:
                    return Url.Link("GetAllPilotsAsync",
                        new
                        {
                            PageNumber = options.PageNumber - 1,
                            options.PageSize,
                            options.SortBy,
                            options.FilterBy,
                            options.SearchBy,
                            options.LicenseID
                        });

                case RessourceUriType.NextPage:
                    return Url.Link("GetAllPilotsAsync",
                        new
                        {
                            PageNumber = options.PageNumber + 1,
                            options.PageSize,
                            options.SortBy,
                            options.FilterBy,
                            options.SearchBy,
                            options.LicenseID
                        });

                default:
                    return Url.Link("GetAllPilotsAsync",
                        new
                        {
                            options.PageNumber,
                            options.PageSize,
                            options.SortBy,
                            options.FilterBy,
                            options.SearchBy,
                            options.LicenseID
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