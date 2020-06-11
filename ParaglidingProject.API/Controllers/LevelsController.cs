using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParaglidingProject.SL.Core.Levels.NS;
using ParaglidingProject.SL.Core.Levels.NS.TransfertObjects;

namespace ParaglidingProject.API.Controllers
{   [Authorize]
    [ApiController]
    [ApiExplorerSettings(GroupName = "level")]
    [Produces("application/json")]
    [Route("api/v1/levels/")]
    public class LevelsController : ControllerBase
    {
        private readonly ILevelsService _levelsService;

        public LevelsController(ILevelsService levelsService)
        {
            _levelsService = levelsService ?? throw new ArgumentNullException(nameof(levelsService));
        }

        [HttpGet("{levelId}", Name = "GetLevelAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LevelDto>> GetLevelAsync([FromRoute] int levelId)
        {
            var level = await _levelsService.GetLevelAsync(levelId);
            if (level == null) return NotFound("Couldn't find any associated Level");
            return Ok(level);
        }

        [HttpGet("", Name = "GetAllLevelsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyCollection<LevelDto>>> GetAllLevelsAsync()
        {
            var levels = await _levelsService.GetAllLevelsAsync();
            if (levels == null) return NotFound("Collection was empty :O");
            return Ok(levels);
        }
    }
}