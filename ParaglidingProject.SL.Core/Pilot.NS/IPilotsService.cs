using System.Collections.Generic;
using System.Threading.Tasks;
using ParaglidingProject.SL.Core.Pilot.NS.TransfertObjects;

namespace ParaglidingProject.SL.Core.Pilot.NS
{
    public interface IPilotsService
    {
        /// <summary>
        /// Coucou
        /// </summary>
        /// <param name="id">test</param>
        /// <returns>coucou</returns>
        Task<PilotDto> GetPilotAsync(int id);

        /// <summary>
        /// Coucou
        /// </summary>
        /// <param name="id">test</param>
        /// <returns>coucou</returns>
        Task<IReadOnlyCollection<PilotDto>> GetAllPilotsAsync();
    }
}
