using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParaglidingProject.SL.Core.Pilot.NS.Helpers;
using ParaglidingProject.SL.Core.Pilot.NS.TransfertObjects;

namespace ParaglidingProject.SL.Core.Pilot.NS
{
    /// <summary>
    /// Pilot's contract manager.
    /// </summary>
    public interface IPilotsService
    {
        /// <summary>
        /// Asynchronously obtain bussiness-related informations of a pilot by searching their id.
        /// </summary>
        /// <param name="id">The pilot id as an integer.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains null by default if source is empty or if no element passes the test specified by predicate.
        /// Otherwise, the task result is a PilotDto with several business-related properties.
        /// <seealso cref="PilotDto">
        /// </returns>
        Task<PilotDto> GetPilotAsync(int id);

        /// <summary>
        /// Asynchronously obtain bussiness-related informations of a list of pilots.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains an empty list by default if source is empty.
        /// Otherwise, the task result is a Collection of type PossessionDto.
        /// <seealso cref="PilotDto">
        /// </returns>
        Task<IReadOnlyCollection<PilotDto>> GetAllPilotsAsync(PilotSSFP options);

        /// <summary>
        /// Asynchronously add a pilot.
        /// </summary>
        /// <param name="pilot"> An object of type Pilot</param>
        /// <returns>
        /// A task result that represents the asynchronous operation. 
        /// </returns>
        Task PostPilotAsync(Models.Pilot pilot);
    }
}
