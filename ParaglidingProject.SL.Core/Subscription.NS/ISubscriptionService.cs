using ParaglidingProject.SL.Core.Subscription.NS.transferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.Subscription.NS
{
    public interface ISubscriptionService
    {
        Task<SubscriptionDto> GetSubscriptionAsync(int id);
        Task<IReadOnlyCollection<SubscriptionDto>> GetAllSubscriptionAsync();
    }
}
