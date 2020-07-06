using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParaglidingProject.SL.Core.Pilot.NS;
using ParaglidingProject.SL.Core.Subscription.NS;
using ParaglidingProject.SL.Core.Subscription.NS.Helpers;
using ParaglidingProject.SL.Core.Subscription.NS.transferObjects;

namespace ParaglidingProject.API.Controllers
{
    /// <summary>
    /// the controller of Subscription
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(GroupName = "subscriptions")]
    [Produces("application/json")]
    [Route("api/v1/Subscriptions/")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _SubscriptionService;
        private readonly IPilotsService _pilotService;

        public SubscriptionController(ISubscriptionService SubscriptionService,IPilotsService pilotsService)
        {
            this._SubscriptionService = SubscriptionService ?? throw new ArgumentNullException(nameof(SubscriptionService));
            _pilotService = pilotsService ?? throw new ArgumentNullException(nameof(pilotsService));
        }

        /// <summary>
        /// gets Subscription by Id
        /// </summary>
        /// <param name="Id">Unique id of a Subscription</param>
        /// <returns>
        /// an actionresult of type 202 that contain a RoleDto
        /// an actionresult of type 404 if no Role was find
        /// <seealso cref="SubscriptionDto"/>
        /// </returns>
        /// <remarks></remarks>
        [HttpGet("{Id}", Name = "GetSubscriptionAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SubscriptionAndPilotsDto>> GetSubscriptionAsync([FromRoute] int id)
        {
            SubscriptionAndPilotsDto subscriptionAndPilotsDto = new SubscriptionAndPilotsDto();
            subscriptionAndPilotsDto.SubscriptionDto = await _SubscriptionService.GetSubscriptionAsync(id);
            if (subscriptionAndPilotsDto.SubscriptionDto == null) return NotFound("Couldn't find any associated Subscription");
            subscriptionAndPilotsDto.pilotDtos = await _pilotService.GetPilotsBySubscription(id);
            if (subscriptionAndPilotsDto.pilotDtos == null) return NotFound("Couldn't fine any associated pilot");
            return Ok(subscriptionAndPilotsDto);
        }
        /// <summary>
        /// get all subscriptions
        /// </summary>
        /// <param name="options">User options to search, sort, filter and paginate a list of subscriptions obtained from a query strings.</param>
        /// <returns>
        /// an actionresult of type 202 who contain a list of paragliderDto
        /// an actionresult of type 404 if no paraglider was find
        /// <seealso cref="SubscriptionDto"/>
        /// </returns>
        [HttpGet("", Name = "GetAllSubscriptionAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyCollection<SubscriptionDto>>> GetAllSubscriptionAsync([FromQuery]SubscriptionSSPF options)
        {
            var Subscriptions = await _SubscriptionService.GetAllSubscriptionAsync(options);
            if (Subscriptions == null) return NotFound("Collection was empty :( ");


            return Ok(Subscriptions);
        }
    }
}

