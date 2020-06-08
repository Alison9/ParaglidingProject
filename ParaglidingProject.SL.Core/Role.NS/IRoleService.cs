using ParaglidingProject.SL.Core.Role.NS.TransfertObjects;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.Role.NS
{
	public interface IRoleService
	{
		Task<RoleDto> GetRoleAsync(int roleId);
		Task<IReadOnlyCollection<RoleDto>> GetAllRoleAsync();

	}
}
