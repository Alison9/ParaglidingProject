using ParaglidingProject.Models;
using ParaglidingProject.SL.Core.Role.NS.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaglidingProject.SL.Core.MapperProfiles
{
  public static class RoleMapping
  {
    public static RoleDto MapRoleDto(this ParaglidingProject.Models.Role role)
    {
      var roleDto = new RoleDto
      {
        roleId = role.ID,
        Name = role.Name,
        PilotFullName = $"{role.Pilot.FirstName} {role.Pilot.LastName}"
      };
      return roleDto;
    }
  }
}
