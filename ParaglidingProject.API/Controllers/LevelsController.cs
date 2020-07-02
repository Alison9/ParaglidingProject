using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParaglidingProject.SL.Core.Levels.NS;
using ParaglidingProject.SL.Core.Levels.NS.TransfertObjects;

namespace ParaglidingProject.API.Controllers
{   
    /// <summary>
    /// Controller for level.
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(GroupName = "levels")]
    [Produces("application/json")]
    [Route("api/v1/levels/")]
    public class LevelsController : ControllerBase
    {
        private readonly ILevelsService _levelsService;
        public LevelsController(ILevelsService levelsService)
        {
            _levelsService = levelsService ?? throw new ArgumentNullException(nameof(levelsService));
        }

        /// <summary>
        /// Get a level by id.
        /// </summary>
        /// <param name="levelId">A level id as an integer found in route.</param>
        /// <returns>
        /// An action result of type 202 which contains a level Dto.
        /// An action result of type 404 if no level was found.
        /// <seealso cref="LevelDto"/>
        /// </returns>
        [HttpGet("{levelId}", Name = "GetLevelAsync")]
        public async Task<ActionResult<LevelDto>> GetLevelAsync([FromRoute] int levelId)
        {
            var level = await _levelsService.GetLevelAsync(levelId);
            if (level == null) return NotFound("Couldn't find any associated Level");
            return Ok(level);
        }

        /// <summary>
        /// Get all levels.
        /// </summary>
        /// <returns>
        /// An action result of type 202 which contains a collection of type level Dto.
        /// An action result of type 404 if no levels were found.
        /// <seealso cref="LevelDto"/>
        /// </returns>
        [HttpGet("", Name = "GetAllLevelsAsync")]
        public async Task<ActionResult<IReadOnlyCollection<LevelDto>>> GetAllLevelsAsync()
        {
            var levels = await _levelsService.GetAllLevelsAsync();
            if (levels == null) return NotFound("Collection was empty :O");
            return Ok(levels);
        }
    }
}