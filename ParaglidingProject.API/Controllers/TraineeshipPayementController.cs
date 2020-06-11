using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParaglidingProject.SL.Core.TraineeshipPayement.NS;
using ParaglidingProject.SL.Core.TraineeshipPayement.NS.TransferObjects;

namespace ParaglidingProject.API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "traineeshipPayements")]
    [Produces("application/json")]
    [Route("api/v1/traineeshipPayments/")]
    public class TraineeshipPayementController : ControllerBase
    {
        private readonly ITraineeshipPaymentService _traineeshipPaymentService;

        public TraineeshipPayementController(ITraineeshipPaymentService traineeshipPaymentService)
        {
            _traineeshipPaymentService = traineeshipPaymentService ?? throw new ArgumentNullException(nameof(traineeshipPaymentService));
        }


        [HttpPost("", Name = "GetTraineeshipPaymentAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TraineeshipPaymentDto>> GetTraineeshipAsync([FromQuery] int traineeshipId, [FromQuery] int pilotId)
        {
            var traineeshipPayment = await _traineeshipPaymentService.GetTraineeshipPaymentAsync(pilotId, traineeshipId);
            if (traineeshipPayment == null) return NotFound("Couldn't find any associated Traineeship payment");
            return Ok(traineeshipPayment);
        }

        [HttpGet("", Name = "GetAllTraineeshipPaymentsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyCollection<TraineeshipPaymentDto>>> GetAllTraineeshipPaymentAsync()
        {
            var traineeshipPayments = await _traineeshipPaymentService.GetAllTraineeshipPaymentAsync();
            if (traineeshipPayments == null) return NotFound("Nothing found.");
            return Ok(traineeshipPayments);
        }

    }
}