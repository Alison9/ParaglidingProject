using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParaglidingProject.SL.Core.ParagliderModel.NS;
using ParaglidingProject.SL.Core.ParagliderModel.NS.Helpers;
using ParaglidingProject.SL.Core.ParagliderModel.NS.TransfertObjects;

namespace ParaglidingProject.API.Controllers
{
    /// <summary>
    /// the controller of paragliderModels
    /// </summary>
    [ApiExplorerSettings(GroupName = "paragliderModels")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ParagliderModelController : ControllerBase
    {
        private readonly IParagliderModelService _ModelParagliderService;
        /// <summary>
        /// ParagliderModel interface constructor.
        /// </summary>
        public ParagliderModelController(IParagliderModelService modelparagliderService)
        {
            _ModelParagliderService = modelparagliderService ?? throw new ArgumentNullException(nameof(modelparagliderService));
        }

        /// <summary>
        /// get a paraglidermodel by id
        /// </summary>
        /// <param name="modelParagliderId">The unique id of a paraglider</param>
        /// <returns>
        /// an actionresult of type 202 who contain a paragliderDto
        /// an actionresult of type 404 if no paraglider was find
        /// <seealso cref="ParagliderModelDto"/>
        /// </returns>
        /// <remarks></remarks>

        [HttpGet("{paragliderModelId}", Name = "GetParagliderModelAsync")]

        public async Task<ActionResult<ParagliderModelDto>> GetParagliderModelAsync([FromRoute] int modelParagliderId)
        {
            var modelParaglider = await _ModelParagliderService.GetParagliderModelAsync(modelParagliderId);
            if (modelParaglider == null) return NotFound("Couldn't find any model of paraglider");
            return Ok(modelParaglider);
        }
        /// <summary>
        /// get all paraglidermodels
        /// </summary>
        /// <param name="options"> User options to sort, search, filter pagination </param>
        /// <returns>
        /// an actionresult of type 202 who contain a list of paragliderModelDto
        /// an actionresult of type 404 if no paraglidermodel was find
        /// <seealso cref="ParagliderModelDto"/>
        /// </returns>

        [HttpGet("", Name = "GetAllModelParaglidersAsync")]

        public async Task<ActionResult<IReadOnlyCollection<ParagliderModelDto>>> GetAllModelParaglidersAsync([FromQuery] ParagliderModelsSSFP options)
        {
            var listModelParaglider = await _ModelParagliderService.GetAllParagliderModelsAsync(options);
            if (listModelParaglider == null) return NotFound("There is no model of paraglider ");
            return Ok(listModelParaglider);
        }
    }
}
