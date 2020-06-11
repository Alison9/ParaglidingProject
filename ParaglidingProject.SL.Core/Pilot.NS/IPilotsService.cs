using System.Collections.Generic;
using System.Threading.Tasks;
using ParaglidingProject.SL.Core.Pilot.NS.TransfertObjects;

namespace ParaglidingProject.SL.Core.Pilot.NS
{
    /// <summary>
    /// Pilot's contract to get a list of pilots or a specific pilot.
    /// </summary>
    public interface IPilotsService
    {
        /// <summary>
        /// Obtain bussiness-related informations of a pilot by searching their id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Pilot Dto containing pilot id, name, address and number of flights</returns>
        Task<PilotDto> GetPilotAsync(int id);

        /// <summary>
        /// Obtain bussiness-related informations of a list of pilots.
        /// </summary>
        /// <returns>Collection of Pilot Dto</returns>
        Task<IReadOnlyCollection<PilotDto>> GetAllPilotsAsync();
    }
}
