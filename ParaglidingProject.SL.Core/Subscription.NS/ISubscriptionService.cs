using ParaglidingProject.SL.Core.Subscription.NS.transferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.Subscription.NS
{
    /// <summary>
    /// A set of asynchronous methods Subscription contract manager
    /// </summary>
    public interface ISubscriptionService
    {
        /// <summary>
        /// Asynchronously retrieve all the Subscriptions for a given id.
        /// </summary>
        /// <param name="id">Indentified subscription int</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result is a SubscriptionDto with several properties.
        /// <seealso cref="SubscriptionDto"/>
        /// </returns>
        Task<SubscriptionDto> GetSubscriptionAsync(int id);
        /// <summary>
        /// Asynchronously retrieve all the Subscriptions.
        /// This method is called without any tracking involved and following the select loading pattern. 
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result is a Collection offini type SubscriptionDto.
        /// <seealso cref="SubscriptionDto"/>
        /// </returns>
        Task<IReadOnlyCollection<SubscriptionDto>> GetAllSubscriptionAsync();
    }
}
