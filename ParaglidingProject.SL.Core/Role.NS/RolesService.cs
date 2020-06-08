using Microsoft.EntityFrameworkCore;
using ParaglidingProject.Data;
using ParaglidingProject.SL.Core.Role.NS.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.Role.NS
{
  public class RolesService : IRoleService
  {
    public readonly ParaglidingClubContext _paraContext;

    public RolesService(ParaglidingClubContext paraContext)
    {
      _paraContext = paraContext ?? throw new ArgumentNullException(nameof(paraContext));
    }


    public async Task<RoleDto> GetRoleAsync(int roleId)
    {

      var role = await _paraContext.Roles
          .AsNoTracking()
          .Select(r => new RoleDto
          {
            roleId = r.ID,
            Name = r.Name,
            PilotFullName = $"{r.Pilot.FirstName} {r.Pilot.LastName}"
          })
          .FirstOrDefaultAsync(r => r.roleId == roleId);

      return role;

    }

    public async Task<IReadOnlyCollection<RoleDto>> GetAllRoleAsync()
    {
      var role = _paraContext.Roles
        .AsNoTracking()
        .Select(r => new RoleDto
        {
          roleId = r.ID,
          Name = r.Name,
          PilotFullName = $"{r.Pilot.FirstName} {r.Pilot.LastName}"
        });

      return await role.ToListAsync();
    }

  }
}
