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
    [Produces("application/json")]
    [Route("api/v1/Traineeships/")]
    public class TraineeshipController : ControllerBase
    {
        private readonly ITraineeShipService _TraineeshipService;

        public TraineeshipController(ITraineeShipService TraineeshipService)
        {
           this._TraineeshipService = TraineeshipService ?? throw new ArgumentNullException(nameof(TraineeShipService));
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
            var traineeShipSortedByLicense = await _TraineeshipService.GetAllTraineeShipSortedByPilotLicense(pilotId);
            if (traineeShipSortedByLicense == null) return NotFound("Pilot not found ! ");
            return Ok(traineeShipSortedByLicense);
        }
    }
}