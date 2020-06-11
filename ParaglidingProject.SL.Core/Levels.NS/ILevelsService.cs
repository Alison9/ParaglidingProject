using ParaglidingProject.SL.Core.Levels.NS.TransfertObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.Levels.NS
{


    /// <summary>
    /// Level's contract manager
    /// </summary>
    public interface ILevelsService
    {



        /// <summary>
        /// find a level with id of the level, name and skills and if it s active
        /// </summary>
        /// <param name="id">unique id as integer of a level</param>
        /// <returns>find a level </returns>
        Task<LevelDto> GetLevelAsync(int id);
        /// <summary>
        /// return the list of levels with id of the level, name and skills and if it s active
        /// </summary>

        /// <returns>list of levels</returns>
        Task<IReadOnlyCollection<LevelDto>> GetAllLevelsAsync();
    }
}
