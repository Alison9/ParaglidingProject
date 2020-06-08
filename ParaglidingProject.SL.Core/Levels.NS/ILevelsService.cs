using ParaglidingProject.SL.Core.Levels.NS.TransfertObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.Levels.NS
{
    public interface ILevelsService
    {
        Task<LevelDto> GetLevelAsync(int id);
        Task<IReadOnlyCollection<LevelDto>> GetAllLevelsAsync();
    }
}
