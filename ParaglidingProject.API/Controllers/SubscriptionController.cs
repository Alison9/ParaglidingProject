using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public SubscriptionController(ISubscriptionService SubscriptionService)
        {
            this._SubscriptionService = SubscriptionService ?? throw new ArgumentNullException(nameof(SubscriptionService));
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
        public async Task<ActionResult<SubscriptionDto>> GetSubscriptionAsync([FromRoute] int Id)
        {
            var subscription = await _SubscriptionService.GetSubscriptionAsync(Id);
            if (subscription == null) return NotFound("Couldn't find any associated Subscription");
            return Ok(subscription);
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
        public async Task<ActionResult<IReadOnlyCollection<SubscriptionDto>>> GetAllSubscriptionAsync(SubscriptionSSPF options)
        {
            var Subscriptions = await _SubscriptionService.GetAllSubscriptionAsync(options);
            if (Subscriptions == null) return NotFound("Collection was empty :( ");


            return Ok(Subscriptions);
        }
    }
}

