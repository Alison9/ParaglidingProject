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
  [Route("api/v1/[controller]")]
  [ApiController]
  public class RolesController : ControllerBase

  {
    public readonly IRoleService _roleService;

    public RolesController(IRoleService RolesService)
    {
      _roleService = RolesService ?? throw new ArgumentNullException(nameof(RolesService));
    }
    [HttpGet("{RoleId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RoleDto>> GetRoleAsync([FromRoute] int roleId)
    {
      var categorie = await _roleService.GetRoleAsync(roleId);
      if (categorie == null) return NotFound("Role n'existe pas");
      return Ok(categorie) ;
    }

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
