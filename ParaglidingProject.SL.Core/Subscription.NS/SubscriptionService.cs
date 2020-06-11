using Microsoft.EntityFrameworkCore;
using ParaglidingProject.Data;
using ParaglidingProject.SL.Core.Subscription.NS.transferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.Subscription.NS
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ParaglidingClubContext _paraContext;
        public SubscriptionService(ParaglidingClubContext paraContext)
        {
            this._paraContext = paraContext;
        }
        /// <inheritdoc />
        public async Task<IReadOnlyCollection<SubscriptionDto>> GetAllSubscriptionAsync()
        {
            var Subscriptions = _paraContext.Subscriptions
                 .AsNoTracking()
                 .Select(s => new SubscriptionDto
                 {
                      Id= s.Year,
                     Amount = s.SubscriptionAmount,
                     NumberOfPayments = s.SubscriptionPayments.Count,
                    IsActive = s.IsActive
                 });

            return await Subscriptions.ToListAsync();
        }
        /// <inheritdoc />
        public async Task<SubscriptionDto> GetSubscriptionAsync(int id)
        {
            var Subscription = await _paraContext.Subscriptions
              .AsNoTracking()
              .Select(s => new SubscriptionDto
              {
                  Id = s.Year,
                  Amount = s.SubscriptionAmount,
                  NumberOfPayments = s.SubscriptionPayments.Count,
                  IsActive = s.IsActive
              })
              .FirstOrDefaultAsync(s => s.Id == id);

            return Subscription;
        }
    }
}
