using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParaglidingProject.SL.Core.Role.NS;
using ParaglidingProject.SL.Core.Role.NS.TransfertObjects;

namespace ParaglidingProject.API.Controllers
{
    /// <summary>
    /// Role's controller
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "roles")]
    [ApiController]
    public class RolesController : ControllerBase

    {
        public readonly IRoleService _roleService;

        public RolesController(IRoleService RolesService)
        {
            _roleService = RolesService ?? throw new ArgumentNullException(nameof(RolesService));
        }

        /// <summary>
        /// gets Role by Id
        /// </summary>
        /// <param name="roleId">Unique id of a role</param>
        /// <returns>
        /// an actionresult of type 202 that contain a RoleDto
        /// an actionresult of type 404 if no Role was find
        /// <seealso cref="RoleDto"/>
        /// </returns>
        /// <remarks></remarks>
        [HttpGet("{RoleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<RoleDto>> GetRoleAsync([FromRoute] int roleId)
        {
            var categorie = await _roleService.GetRoleAsync(roleId);
            if (categorie == null) return NotFound("Role n'existe pas");
            return Ok(categorie);
        }


        /// <summary>
        /// get all Roles
        /// </summary>
        /// <returns>
        /// an actionresult of type 202 that contains all RoleDto
        /// an actionresult of type 404 if no RoleDto was find
        /// <seealso cref="RoleDto"/>
        /// </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyCollection<RoleDto>>> GetAllRoleAsync()
        {
            var categories = await _roleService.GetAllRoleAsync();
            return Ok(categories);
        }
    }


}
