using System.Collections.Generic;
using System.Threading.Tasks;
using ParaglidingProject.SL.Core.TransfertObjects;

namespace ParaglidingProject.SL.Core
{
    public interface IPilotsService
    {
        Task<PilotDto> GetPilotAsync(int id);
        Task<IReadOnlyCollection<PilotDto>> GetAllPilotsAsync();
    }
}
