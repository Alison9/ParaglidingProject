using ParaglidingProject.SL.Core.Site.NS.Helpers;
using ParaglidingProject.SL.Core.Site.NS.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.Site.NS
{
    /// <summary>
    /// A set of asynchronous methods each representing a contract to be fulfilled 
    /// </summary>
    public interface ISitesService
    {
        /// <summary>
        /// Asynchronously retrieve a specific Site by its id.
        /// This method is called without any tracking involved and following the select loading pattern.
        /// </summary>
        /// <param name="id">The id of the Site as an integer</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result is a SiteDto with several properties.
        /// <seealso cref="SiteDto"/>
        /// </returns>
        Task<SiteDto> GetSiteAsync(int id);


        /// <summary>
        /// Asynchronously retrieve all the Sites.
        /// This method is called without any tracking involved and following the select loading pattern. 
        /// </summary>
        /// <returns>
        /// The task result is a Collection of type SiteDto.
        /// <seealso cref="SiteDto"/>
        /// </returns>
        Task<IReadOnlyCollection<SiteDto>> GetAllSitesAsync(SiteSSFP options);

        /// <summary>
        /// Asynchronously retrieve all the Landing Sites.
        /// This method is called without any tracking involved and following the select loading pattern. 
        /// </summary>
        /// <returns>
        /// The task result is a Collection of type LandingDto.
        /// <seealso cref="LandingDto"/>
        /// </returns>
        Task<IReadOnlyCollection<LandingDto>> GetAllLandingAsync();

        /// <summary>
        /// Asynchronously retrieve all the Take Off Sites.
        /// This method is called without any tracking involved and following the select loading pattern. 
        /// </summary>
        /// <returns>
        /// The task result is a Collection of type TakeoffDto.
        /// <seealso cref="TakeoffDto"/>
        /// </returns>
        Task<IReadOnlyCollection<TakeoffDto>> GetAllTakeOffAsync();
        void CreateSite(SiteDto siteDto);
    }
}
