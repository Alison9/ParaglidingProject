using ParaglidingProject.SL.Core.Possession.NS.Helpers;
using ParaglidingProject.SL.Core.Possession.NS.TransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.Possession.NS
{
    /// <summary>
    /// A set of asynchronous methods each representing a contract to be fulfilled 
    /// </summary>
   public interface IPossessionsService 
    {
        /// <summary>
        /// Asynchronously retrieve all the Possessions for a given Pilot and a given License.
        /// This method is called without any tracking involved and following the select loading pattern.
        /// </summary>
        /// <param name="pilotId">The piloteId as an integer</param>
        /// <param name="licenseId">The licenseId as an integer</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains null by default if source is empty or if no element passes the test specified by predicate.
        /// Otherwise, the task result is a PossessionDto with several properties.
        /// <seealso cref="PossessionDto"/>
        /// </returns>
        Task<PossessionDto> GetPossessionAsync(int pilotId, int licenseId);

    /// <summary>
    /// Asynchronously retrieve all the Possessions.
    /// This method is called without any tracking involved and following the select loading pattern. 
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains an empty list by default if source is empty.
    /// Otherwise, the task result is a Collection od type PossessionDto.
    ///  <param name="options"> PosessionSSFP for search, sort, filter and pagination feature> </param>
    /// <seealso cref="PossessionDto"/>
    /// </returns>
    Task<IReadOnlyCollection<PossessionDto>> GetAllPossessionsAsync(PossessionSSFP options);

        /// <summary>
        /// Asynchronously retrieve all the Possessions for a given Pilot.
        /// This method is called without any tracking involved and following the select loading pattern. 
        /// </summary>
        /// <param name="pilotId">The piloteId as an integer</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains null by default if source Pilot is empty.
        /// The task result contains an empty list by default if source collection is empty.
        /// Otherwise, the task result is a Collection od type PossessionDto.
        /// <seealso cref="PossessionDto"/>
        /// </returns>
        Task<IReadOnlyCollection<PossessionDto>> GetPossessionByPilotAsync(int pilotId);
    }
}
