using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParaglidingProject.SL.Core.TraineeshipPayement.NS;
using ParaglidingProject.SL.Core.TraineeshipPayement.NS.TransferObjects;
using ParaglidingProject.SL.Core.TraineeshipPayment.NS.Helpers;

namespace ParaglidingProject.API.Controllers
{
    /// <summary>
    /// TraineeshipPayment's Controller
    /// </summary>
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

        /// <summary>
        /// Get a Traineeship
        /// </summary>
        /// <param name="traineeshipId">traineeshipId as an integer</param>
        /// <param name="pilotId">pilotId as an integer</param>
        /// <returns>An ActionResult of type 200 response who contains a TraineeshipPaymentDto.
        /// An ActionResult of type 404 response if no TraineeshipPayment was found.
        /// <seealso cref="TraineeshipPaymentDto"/>
        /// </returns>
        [HttpPost("", Name = "GetTraineeshipPaymentAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TraineeshipPaymentDto>> GetTraineeshipAsync([FromQuery] int traineeshipId, [FromQuery] int pilotId)
        {
            var traineeshipPayment = await _traineeshipPaymentService.GetTraineeshipPaymentAsync(pilotId, traineeshipId);
            if (traineeshipPayment == null) return NotFound("Couldn't find any associated Traineeship payment");
            return Ok(traineeshipPayment);
        }

        /// <summary>
        /// Get all TraineeshipPayments
        /// </summary>
        /// <param name="options">options as TraineeshipPaymentSSFP</param>
        /// <returns>An ActionResult of type 200 response who contains a IReadOnlyCollection of TraineeshipPaymentDto.
        /// An ActionResult of type 404 response if no TraineeshipPayment was found.
        /// <seealso cref="TraineeshipPaymentDto"/>
        /// </returns>
        [HttpGet("", Name = "GetAllTraineeshipPaymentsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyCollection<TraineeshipPaymentDto>>> GetAllTraineeshipPaymentAsync([FromQuery] TraineeshipPaymentSSFP options)
        {
            var traineeshipPayments = await _traineeshipPaymentService.GetAllTraineeshipPaymentAsync(options);
            if (traineeshipPayments == null) return NotFound("Nothing found.");

            var previousPageLink = options.HasPrevious ? CreateTraineeshipPaymentsRessourceUri(options, RessourceUriType.PreviousPage) : null;
            var nextPageLink = options.HasNext ? CreateTraineeshipPaymentsRessourceUri(options, RessourceUriType.NextPage) : null;

            var paginationMetada = new
            {
                options.TotalCount,
                options.PageSize,
                options.PageNumber,
                options.TotalPages,
                previousPageLink,
                nextPageLink
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetada));

            return Ok(traineeshipPayments);
        }

        /// <summary>
        /// Creation of a TraineeshipPayment ressource Uri
        /// </summary>
        /// <param name="options">options as TraineeshipPaymentSSFP</param>
        /// <param name="type">type as RessourceUriType</param>
        /// <returns>An url of type IUrlHelper</returns>
        private string CreateTraineeshipPaymentsRessourceUri(TraineeshipPaymentSSFP options, RessourceUriType type)
        {
            switch(type)
            {
                case RessourceUriType.PreviousPage:
                    return Url.Link("GetAllTraineeshipPaymentsAsync",
                        new
                        {
                            PageNumber = options.PageNumber - 1,
                            options.PageSize
                        }) ;

                case RessourceUriType.NextPage:
                    return Url.Link("GetAllTraineeshipPaymentsAsync",
                        new
                        {
                            PageNumber = options.PageNumber + 1,
                            options.PageSize
                        });

               default:
                    return Url.Link("GetAllTraineeshipPaymentsAsync",
                        new
                        {
                            options.PageNumber,
                            options.PageSize
                        });
            }
        }

        public enum RessourceUriType
        {
            PreviousPage = 0,
            NextPage = 1
        }

    }
}