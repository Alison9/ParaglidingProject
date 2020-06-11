using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParaglidingProject.SL.Core.ParagliderModel.NS;
using ParaglidingProject.SL.Core.ParagliderModel.NS.TransfertObjects;

namespace ParaglidingProject.API.Controllers
{
  [Route("api/v1/[controller]")]
  [Produces("application/json")]
  [ApiController]
    public class ParagliderModelController : ControllerBase
    {
    private readonly IParagliderModelService _ModelParagliderService;

    public ParagliderModelController(IParagliderModelService modelparagliderService)
    {
      _ModelParagliderService = modelparagliderService ?? throw new ArgumentNullException(nameof(modelparagliderService));
    }
    [HttpGet("{modelParagliderId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ParagliderModelDto>> GetParagliderModelAsync([FromRoute] int modelParagliderId)
    {
      var modelParaglider = await _ModelParagliderService.GetParagliderModelAsync(modelParagliderId);
      if (modelParaglider == null) return NotFound("Couldn't find any model of paraglider");
      return Ok(modelParaglider);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IReadOnlyCollection< ParagliderModelDto>>> GetAllModelParaglidersAsync()
    {
      var listModelParaglider = await _ModelParagliderService.GetAllParagliderModelsAsync();
      if (listModelParaglider == null) return NotFound("There is no model of paraglider ");
      return Ok(listModelParaglider);
    }
  }
}
