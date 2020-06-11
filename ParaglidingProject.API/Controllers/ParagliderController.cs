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
    /// <summary>
    /// the controller of paraglider
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(GroupName = "paragliders")]
    [Produces("application/json")]
    [Route("api/v1/paragliders/")]


    public class ParagliderController : ControllerBase
    {
        private readonly IParagliderService _paragliderService;

       
        public ParagliderController(IParagliderService paragliderService)
        {
            _paragliderService = paragliderService ?? throw new ArgumentNullException(nameof(paragliderService));
        }


        /// <summary>
        /// get a paraglider by id
        /// </summary>
        /// <param name="paragliderId">The unique id of a paraglider</param>
        /// <returns>
        /// an actionresult of type 202 who contain a paragliderDto
        /// an actionresult of type 404 if no paraglider was find
        /// <seealso cref="ParagliderDto"/>
        /// </returns>
        /// <remarks></remarks>
        [HttpGet("{paragliderId}", Name = "GetParagliderAsync")]

        public async Task<ActionResult<ParagliderDto>> GetParagliderAsync([FromRoute] int paragliderId)
        {
            var paraglider = await _paragliderService.GetParagliderAsync(paragliderId);
            if (paraglider == null) return NotFound("Couldn't find any associated Paraglider");
            return Ok(paraglider);
        }

        /// <summary>
        /// get all paraglider
        /// </summary>
        /// <returns>
        /// an actionresult of type 202 who contain a list of paragliderDto
        /// an actionresult of type 404 if no paraglider was find
        /// <seealso cref="ParagliderDto"/>
        /// </returns>
        [HttpGet("", Name = "GetAllParaglidersAsync")]
     
        public async Task<ActionResult<IReadOnlyCollection<ParagliderDto>>> GetAllParaglidersAsync()
        {
            var paraglider = await _paragliderService.GetAllParaglidersAsync();
            if (paraglider == null) return NotFound("There is no paraglider ");
            return Ok(paraglider);
        }
    }
}