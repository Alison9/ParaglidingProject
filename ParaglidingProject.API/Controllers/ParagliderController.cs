using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParaglidingProject.SL.Core.Paraglider.NS;
using ParaglidingProject.SL.Core.Paraglider.NS.TransfertObjects;

namespace ParaglidingProject.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/paragliders/")]
    public class ParagliderController : ControllerBase
    {
        private readonly IParagliderService _paragliderService;

        public ParagliderController(IParagliderService paragliderService)
        {
            _paragliderService = paragliderService ?? throw new ArgumentNullException(nameof(paragliderService));
        }
        [HttpGet("{paragliderId}", Name = "GetParagliderAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ParagliderDto>> GetPilotAsync([FromRoute] int paragliderId)
        {
            var paraglider = await _paragliderService.GetParagliderAsync(paragliderId);
            if (paraglider == null) return NotFound("Couldn't find any associated Paraglider");
            return Ok(paraglider);
        }

        [HttpGet("", Name = "GetAllParaglidersAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyCollection<ParagliderDto>>> GetAllPilotsAsync()
        {
            var paraglider = await _paragliderService.GetAllParaglidersAsync();
            if (paraglider == null) return NotFound("There is no paraglider ");
            return Ok(paraglider);
        }
    }
}