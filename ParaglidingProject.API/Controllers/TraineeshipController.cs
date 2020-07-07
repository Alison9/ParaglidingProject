using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ParaglidingProject.SL.Core.Pilot.NS;
using ParaglidingProject.SL.Core.TraineeShip.NS;
using ParaglidingProject.SL.Core.TraineeShip.NS.NewFolder1;
using ParaglidingProject.SL.Core.TraineeShip.NS.TransferObjects;

namespace ParaglidingProject.API.Controllers
{

    [ApiController]
    [ApiExplorerSettings(GroupName = "traineeships")]
    [Produces("application/json")]
    [Route("api/v1/Traineeships/")]
    public class TraineeshipController : ControllerBase
    {
        private readonly ITraineeShipService _TraineeshipService;
        private readonly IPilotsService _PilotService;

        [AllowAnonymous]
        [HttpPatch("{traineeshipsId}", Name = "PatchTraineeshipAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult> PatchTraineeshipAsync([FromRoute] int traineeshipId, [FromBody] JsonPatchDocument<TraineeshipPatchDto> patchDocument)
        {
            var traineeshipToPatch = await _TraineeshipService.GetTraineeshipToPatchAsync(traineeshipId);
            if (traineeshipToPatch == null) return NotFound("Traineeship does not exists");

            patchDocument.ApplyTo(traineeshipToPatch, ModelState);
            if (!TryValidateModel(traineeshipToPatch)) return ValidationProblem(ModelState);


            var patchSuccess = await _TraineeshipService.UpdateTraineeshipAsync(traineeshipId, traineeshipToPatch);
            return patchSuccess == true ? NoContent() : StatusCode(StatusCodes.Status503ServiceUnavailable);
        }

        public TraineeshipController(ITraineeShipService TraineeshipService, IPilotsService PilotService)
        {
           this._TraineeshipService = TraineeshipService ?? throw new ArgumentNullException(nameof(TraineeShipService));
            this._PilotService = PilotService ?? throw new ArgumentNullException(nameof(PilotsService));
        }

        [HttpGet("{traineeshipid}", Name = "GetTraineeShipAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TraineeshipAndPilotsDto>>GetTraineeShipAsync([FromRoute] int traineeshipid)
        {
            TraineeshipAndPilotsDto traineeshipAndPilotsDto = new TraineeshipAndPilotsDto();

            var traineeship = await _TraineeshipService.GetTraineeShipAsync(traineeshipid);
            if (traineeship == null) return NotFound("Couldn't find any associated Traineeship");
            var pilots = await _PilotService.GetPilotsByTraineeship(traineeshipid);
            if (pilots == null) return NotFound("Couldn't find any associated pilots");

            traineeshipAndPilotsDto.TraineeshipDto = traineeship;
            traineeshipAndPilotsDto.PilotsDto = pilots;

            return Ok(traineeshipAndPilotsDto);
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        [HttpGet("", Name = "GetAllTraineeShipAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyCollection<TraineeShipDto>>> GetAllTraineeShipAsync([FromQuery] TraineeshipSSFP options)
        {
            var traineeships= await _TraineeshipService.GetAllTraineeShipAsync(options);
            if (traineeships == null) return NotFound("Collection was empty :)");
            var previousPageLink = options.HasPrevious ? CreateUriTraineeship(options, RessourceUriType.PreviousPage) : null;
            var nextPageLink = options.HasNext ? CreateUriTraineeship(options, RessourceUriType.NextPage) : null;

            var paginationMetadata = new
            {
                options.TotalCount,
                options.PageSize,
                options.PageNumber,
                options.TotalPages,
                options.FilterBy,
                options.SortBy,
                previousPageLink,
                nextPageLink
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(traineeships);
        }
        /// <summary>
        /// </summary>
        /// <param name="options"> the user custom options for search, sort ,filter page</param>
        /// <param name="type"> one element of the enumeration  to distinguish multiple type of url to create</param>
        /// <returns></returns>

        private string CreateUriTraineeship(TraineeshipSSFP options, RessourceUriType type)
        {
            switch (type)
            {
                case RessourceUriType.PreviousPage:
                    return Url.Link("GetAllTraineeShipAsync",
                        new
                        {
                            PageNumber = options.PageNumber - 1,
                            options.PageSize,
                             options.SortBy,
                             options.FilterBy
                        });

                case RessourceUriType.NextPage:
                    return Url.Link("GetAllTraineeShipAsync",
                        new
                        {
                            PageNumber = options.PageNumber + 1,
                            options.PageSize,
                            options.SortBy,
                            options.FilterBy
                        });

                default:
                    return Url.Link("GetAllTraineeShipAsync",
                        new
                        {
                            options.PageNumber,
                            options.PageSize,
                            options.SortBy,
                            options.FilterBy

                        });
            }
        }
         enum RessourceUriType
        {
            PreviousPage = 0,
            NextPage = 1
        }




        [HttpPost("{pilotId}", Name = "GetTrainsheepByPilotLicense")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TraineeShipSortByPilotLicenseDto>> GetAvailableTraineeShipLicenseByPilotAsync([FromRoute] int pilotId)
        {
            var pilot = await _PilotService.GetPilotAsync(pilotId);
            if (pilot == null) return NotFound("Couldn't find any associated Pilot");

            var traineeShipSortedByLicense = await _TraineeshipService.GetAllTraineeShipSortedByPilotLicense(pilotId);
            if (traineeShipSortedByLicense == null) return NotFound("Pilot not found ! ");
            return Ok(traineeShipSortedByLicense);
        }

        [HttpGet("pilot/{pilotId}", Name = "GetTraineeshipsByPilotAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyCollection<TraineeShipDto>>> GetTraineeshipsByPilotAsync([FromRoute] int pilotId)
        {
          
            var pilot = await _PilotService.GetPilotAsync(pilotId);
            if (pilot == null) return NotFound("Couldn't find any associated Pilot");

            var traineeships = await _TraineeshipService.GetTraineeshipsByPilotAsync(pilotId);
            if (traineeships == null || traineeships.Count == 0) return NotFound("The pilot hasn't follow any traneeships yet");
            return Ok(traineeships);
        }

        [HttpPost]
        public async Task<ActionResult<TraineeShipDto>> CreateTraineeship([FromBody] TraineeShipDto pTraineeshipDto)
        {
            _TraineeshipService.CreateTraineeship(pTraineeshipDto);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<TraineeShipDto>> EditTraineeship([FromBody] TraineeShipDto pTraineeshipDto)
        {
            _TraineeshipService.EditTraineeship(pTraineeshipDto);
            return Ok();
        }

        [HttpDelete("{pTraineeshipId}")]
        public async Task<ActionResult<TraineeShipDto>> DeleteTraineeship([FromRoute] int pTraineeshipId)
        {
            _TraineeshipService.DeleteTraineeship(pTraineeshipId);
            return Ok();
        }
    }
}