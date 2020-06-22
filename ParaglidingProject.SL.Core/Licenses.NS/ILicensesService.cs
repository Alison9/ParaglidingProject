using ParaglidingProject.SL.Core.Licenses.NS.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.Licenses.NS
{
    public interface ILicensesService
    {
        /// <summary>
        /// Asynchronously retrieve a License for a given Id.
        /// This method is called without any tracking involved and following the select loading pattern.
        /// </summary>
        /// <param name="id">id as an integer</param>
        /// <returns>A task that represents the asynchronous operation.
        /// The task result contains null by default if source is empty or if no element passes the test specified by predicate.
        /// Otherwise, the task result is a LevelDto with several properties.
        /// <seealso cref="LicenseDto"/>
        /// </returns>
        Task<LicenseDto> GetLicenseAsync(int id);
    }
}
