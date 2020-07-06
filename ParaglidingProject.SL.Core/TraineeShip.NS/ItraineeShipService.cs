using ParaglidingProject.SL.Core.TraineeShip.NS.NewFolder1;
using ParaglidingProject.SL.Core.TraineeShip.NS.TransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.TraineeShip.NS
{
    /// <summary>
    /// A set of asynchronous methods each representing a contract to be fulfilled 
    /// </summary>
    public interface ITraineeShipService
    {
        /// <summary>
        /// Asynchronously retrieve a traineeship for a given Id.
        /// This method is called without any tracking involved and following the select loading pattern.
        /// </summary>
        /// <param name="id">The Id as an integer</param>

        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains null by default if source is empty or if no element passes the test specified by predicate.
        /// Otherwise, the task result is a TraineeShipDto with several properties.
        /// <seealso cref="TraineeShipDto"/>
        /// </returns>
        Task<TraineeShipDto> GetTraineeShipAsync(int id);
        /// <summary>
        /// Asynchronously retrieve all the traineeships.
        /// This method is called without any tracking involved and following the select loading pattern. 
        /// </summary>

        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains null by default if source Pilot is empty.
        /// The task result contains an empty list by default if source collection is empty.
        /// Otherwise, the task result is a Collection of type TraineeShipDto.
        ///  <param name="options">options is the type of traineeshipsSSFP (sort, search, filter, paging)</param>
        /// <seealso cref="TraineeShipDto"/>
        /// </returns>
        Task<IReadOnlyCollection<TraineeShipDto>> GetAllTraineeShipAsync(TraineeshipSSFP options);
        /// <summary>
        /// Asynchronously retrieve all the traineeships for a given pilotLicense.
        /// This method is called without any tracking involved and following the select loading pattern. 
        /// </summary>
        /// <param name="pilotLicenseId">The pilotLicenseId as an integer</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains null by default if source Pilot is empty.
        /// The task result contains an empty list by default if source collection is empty.
        /// Otherwise, the task result is a Collection of type TraineeShipSortByPilotLicenseDto.
        /// <seealso cref="TraineeShipSortByPilotLicenseDto"/>
        /// </returns>
        Task<IReadOnlyCollection<TraineeShipSortByPilotLicenseDto>> GetAllTraineeShipSortedByPilotLicense(int pilotLicenseId);
        /// <summary>
        /// Asynchronously retrieve all the traineeships for a given Pilot.
        /// This method is called without any tracking involved and following the select loading pattern. 
        /// </summary>
        /// <param name="pilotId">The piloteId as an integer</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains null by default if source Pilot is empty.
        /// The task result contains an empty list by default if source collection is empty.
        /// Otherwise, the task result is a Collection of type TraineeShipDto.
        /// <seealso cref="TraineeShipDto"/>
        /// </returns>
        Task<IReadOnlyCollection<TraineeShipDto>> GetTraineeshipsByPilotAsync(int pilotId);
        public void CreateTraineeship(TraineeShipDto pTraineeshipDto);

        public void EditTraineeship(TraineeShipDto pTraineeshipDto);

        public void DeleteTraineeship(int pTraineeshipId);


    }
}
