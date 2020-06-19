using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        public TraineeshipController(ITraineeShipService TraineeshipService, IPilotsService PilotService)
        {
           this._TraineeshipService = TraineeshipService ?? throw new ArgumentNullException(nameof(TraineeShipService));
            this._PilotService = PilotService ?? throw new ArgumentNullException(nameof(PilotsService));
        }

        [HttpGet("{Traineeshipid}", Name = "GetTraineeShipAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TraineeShipDto>>GetTraineeShipAsync([FromRoute] int Traineeshipid)
        {
            var traineeship = await _TraineeshipService.GetTraineeShipAsync(Traineeshipid);
            if (traineeship == null) return NotFound("Couldn't find any associated Traineeship");
            return Ok(traineeship);
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
                    return Url.Link("GetAllPilotsAsync",
                        new
                        {
                            PageNumber = options.PageNumber - 1,
                            options.PageSize                           
                        });

                case RessourceUriType.NextPage:
                    return Url.Link("GetAllPilotsAsync",
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
                            options.PageSize
                            
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
    }
}