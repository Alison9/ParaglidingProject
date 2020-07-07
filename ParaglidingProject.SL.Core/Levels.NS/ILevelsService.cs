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
        /// Asynchronously retrieve a Level for a given Id.
        /// This method is called without any tracking involved and following the select loading pattern.
        /// </summary>
        /// <param name="id">The LevelId as an integer</param>
      
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains null by default if source is empty or if no element passes the test specified by predicate.
        /// Otherwise, the task result is a LevelDto with several properties.
        /// <seealso cref="LevelDto"/>
        /// </returns>
        Task<LevelDto> GetLevelAsync(int id);
        /// <summary>
        /// Asynchronously retrieve all the Levels.
        /// This method is called without any tracking involved and following the select loading pattern. 
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains an empty list by default if source is empty.
        /// Otherwise, the task result is a Collection of type LevelDto.
        /// <seealso cref="LevelDto"/>
        /// </returns>
        Task<IReadOnlyCollection<LevelDto>> GetAllLevelsAsync();

      
        Task <bool?> UpdateLevelAsync(int LevelId, LevelPatchDto patchDto);

       
        Task <LevelPatchDto> GetLevelToPatchAsync(int LevelId);



    }
}
