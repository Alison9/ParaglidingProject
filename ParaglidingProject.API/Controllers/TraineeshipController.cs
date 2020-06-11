using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParaglidingProject.SL.Core.Pilot.NS;
using ParaglidingProject.SL.Core.TraineeShip.NS;
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

        [HttpGet("", Name = "GetAllTraineeShipAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyCollection<TraineeShipDto>>> GetAllTraineeShipAsync()
        {
            var traineeships= await _TraineeshipService.GetAllTraineeShipAsync();
            if (traineeships == null) return NotFound("Collection was empty :( ");
            return Ok(traineeships);
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