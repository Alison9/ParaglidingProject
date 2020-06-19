using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParaglidingProject.SL.Core.Pilot.NS;
using ParaglidingProject.SL.Core.Possession.NS;
using ParaglidingProject.SL.Core.Possession.NS.Helpers;
using ParaglidingProject.SL.Core.Possession.NS.TransferObjects;

namespace ParaglidingProject.API.Controllers
{

  /// <summary>
  /// Possesion controller.
  /// </summary>

  [ApiController]
  [ApiExplorerSettings(GroupName = "possessions")]
  [Produces("application/json")]
  [Route("api/v1/possessions/")]
  public class PossessionsController : ControllerBase
  {
    private readonly IPossessionsService _possessionsService;
    private readonly IPilotsService _PilotService;

  
    /// <summary>
    /// Possesion interface constructor.
    /// </summary>
    public PossessionsController(IPossessionsService possessionsService, IPilotsService pilotsService)
    {
      _possessionsService = possessionsService ?? throw new ArgumentNullException(nameof(possessionsService));
      _PilotService = pilotsService ?? throw new ArgumentNullException(nameof(pilotsService));
    }

    /// <summary>
    /// Asynchronously getting a Possession by PilotId and LicenseId.
    /// </summary>
    /// <param name="Pilotid">Id of the pilot</param>
    /// <param name="Licenseid">Id of the pilot</param>
    /// <returns> 
    /// Status 202 containing a PossessionDto.
    /// Status 404 if no Possessions was found.
    /// </returns>
    /// <seealso cref="PossessionDto"/>
    [HttpPost("", Name = "GetPossessionAsync")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PossessionDto>> GetPossessionAsync([FromQuery] int Pilotid, [FromQuery]int Licenseid)
    {
      var possession = await _possessionsService.GetPossessionAsync(Pilotid, Licenseid);
      if (possession == null) return NotFound("Couldn't find any associated Possession");
      return Ok(possession);
    }
    /// <summary>
    /// Asynchronously getting a collection of PossessionDto.
    /// </summary>
    /// <returns> 
    /// Status 202 containing a collection of PossessionDto.
    /// Status 404 if no Possessions was found.
    /// </returns>
    /// <seealso cref="PossessionDto"/>
    [HttpGet("", Name = "GetAllPossessionsAsync")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IReadOnlyCollection<PossessionDto>>> GetAllPossessionsAsync([FromQuery]PossessionSSFP options)
    {
      var possessions = await _possessionsService.GetAllPossessionsAsync(options);
      if (possessions == null) return NotFound("Collection was empty");


      var previousPageLink = options.HasPrevious ? CreateResourceUri(options, RessourceUriType.PreviousPage) : null;
      var nextPageLink = options.HasNext ? CreateResourceUri(options, RessourceUriType.NextPage) : null;

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
      return Ok(possessions);
    }
    /// <summary>
    /// Pagination
    /// </summary>
    /// <param name="options"> PosessionSSFP for search, sort, filter and pagination feature> </param>
    /// <returns>

    private string CreateResourceUri(PossessionSSFP options, RessourceUriType type)
    {
      switch (type)
      {
        case RessourceUriType.PreviousPage:
          return Url.Link("GetAllPossessionsAsync",
              new
              {
                PageNumber = options.PageNumber - 1,
                options.PageSize
              });

        case RessourceUriType.NextPage:
          return Url.Link("GetAllPossessionsAsync",
              new
              {
                PageNumber = options.PageNumber + 1,
                options.PageSize
              });

        default:
          return Url.Link("GetAllPilotsAsync",
              new
              {
                options.PageNumber,
                options.PageSize,
              });
      }
    }


    public enum RessourceUriType
    {
      PreviousPage = 0,
      NextPage = 1
    }



    /// <summary>
    /// Asynchronously getting all Possession for a Pilot with his Id.
    /// </summary>
    /// <param name="pilotId"> Id of the pilot</param>
    /// <returns> 
    /// Status 202 containing a collection PossessionDto for a specific PilotId.
    /// Status 404 if no Possessions was found.
    /// </returns>
    /// <seealso cref="PossessionDto"/>
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
    

