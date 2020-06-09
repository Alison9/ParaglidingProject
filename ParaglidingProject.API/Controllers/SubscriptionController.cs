using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParaglidingProject.SL.Core.Subscription.NS;
using ParaglidingProject.SL.Core.Subscription.NS.transferObjects;

namespace ParaglidingProject.API.Controllers
{

    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/Subscriptions/")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _SubscriptionService;

        public SubscriptionController(ISubscriptionService SubscriptionService)
        {
            this._SubscriptionService = SubscriptionService ?? throw new ArgumentNullException(nameof(SubscriptionService));
        }

        [HttpGet("{Id}", Name = "GetSubscriptionAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult< SubscriptionDto>> GetSubscriptionAsync([FromRoute] int Id)
        {
            var subscription = await _SubscriptionService.GetSubscriptionAsync(Id);
            if (subscription== null) return NotFound("Couldn't find any associated Subscription");
            return Ok(subscription);
        }

        [HttpGet("", Name = "GetAllSubscriptionAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyCollection<SubscriptionDto>>> GetAllSubscriptionAsync()
        {
            var Subscriptions  = await _SubscriptionService.GetAllSubscriptionAsync();
            if (Subscriptions == null) return NotFound("Collection was empty :( ");
            return Ok(Subscriptions);
        }
    }
} 
