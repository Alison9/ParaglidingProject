using ParaglidingProject.SL.Core.Role.NS.TransfertObjects;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.Role.NS
{  ///<summary>
   /// Role contract to get a role or a list of roles in the club commitee///
   /// </summary>
	public interface IRoleService
	{
    ///<summary>
	  ///Return the id(int), name and the particaption in the club commitee for a pilot(PilotDto)
	  ///</summary>
	  ///<returns> Return a boolean IsActif=True if a pilot is in the club commitee.</returns>
	  ///seealso cref="RoleDto"
		
		Task<RoleDto> GetRoleAsync(int roleId);
    ///<summary>
	  ///Return a list of pilots and their participation in the club commitee with a boolean IsActif
    //</summary>
    ///<return> Return a collection of PilotDto and a boolean IsActif for each
		Task<IReadOnlyCollection<RoleDto>> GetAllRoleAsync();

	}
}
