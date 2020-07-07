using Microsoft.EntityFrameworkCore;

using ParaglidingProject.Data;
using ParaglidingProject.SL.Core.Helpers;
using ParaglidingProject.SL.Core.Pilot.NS.TransfertObjects;
using ParaglidingProject.SL.Core.Subscription.NS.Helpers;
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
        public async Task<IReadOnlyCollection<SubscriptionDto>> GetAllSubscriptionAsync(SubscriptionSSPF options)
        {
            var subscriptionsQuery = _paraContext.Subscriptions
                 .AsNoTracking()
                 .FilterSubscriptionBy(options.filterBy, options.AmountTrigger)
                 .SubscriptionSortBy(options.orderBy)
                 .Select(s => new SubscriptionDto
                 {
                      Id= s.Year,
                     Amount = s.SubscriptionAmount,
                     NumberOfPayments = s.SubscriptionPayments.Count,
                     IsActive = s.IsActive,
                     TotalAmount = s.SubscriptionPayments.Count* s.SubscriptionAmount

                 });
            
            options.SetPagingValues(subscriptionsQuery);
            var pagedQuery = subscriptionsQuery.Page(options.PageNumber - 1, options.PageSize);
            return await pagedQuery.ToListAsync();
        }
        /// <inheritdoc />
        public async Task<SubscriptionDto> GetSubscriptionAsync(int id)
        {
            var subscription = await _paraContext.Subscriptions
              .AsNoTracking()
              .Select(s => new SubscriptionDto
              {
                  Id = s.Year,
                  Amount = s.SubscriptionAmount,
                  NumberOfPayments = s.SubscriptionPayments.Count,
                  IsActive = s.IsActive,
                  TotalAmount = s.SubscriptionPayments.Count * s.SubscriptionAmount
              })
              .FirstOrDefaultAsync(s => s.Id == id);

            return subscription;
        }
        public async Task<SubscriptionDto> GetPilotsBySubscription(int id)
        {
            SubscriptionDto subscriptionDto = new SubscriptionDto();
            subscriptionDto = await _paraContext.Subscriptions
                .AsNoTracking()
                .Select(s => new SubscriptionDto
                {
                    Id = s.Year,
                    Amount = s.SubscriptionAmount,
                    NumberOfPayments = s.SubscriptionPayments.Count,
                    IsActive = s.IsActive,
                    TotalAmount = s.SubscriptionPayments.Count * s.SubscriptionAmount
                }).FirstOrDefaultAsync(s => s.Id == id);

            return subscriptionDto;

        }
        public void CreateSubscription(SubscriptionDto pSubscriptionDto)
        {
            _paraContext.Subscriptions.Add(new Models.Subscription
            {
                Year = pSubscriptionDto.Id,
                IsActive = true,
                SubscriptionAmount = pSubscriptionDto.Amount
            });

             _paraContext.SaveChanges();
        }
        public void UpdateSubscription(SubscriptionDto pSubscriptionDto)
        {
            Models.Subscription subscriptionToModify = _paraContext.Subscriptions.Where(s => s.Year == pSubscriptionDto.Id).FirstOrDefault();

            subscriptionToModify.SubscriptionAmount = pSubscriptionDto.Amount;

            _paraContext.Subscriptions.Update(subscriptionToModify);
            _paraContext.SaveChanges();
        }
        public void DeleteSubscription(int id)
        {
            Models.Subscription subscriptionToSoftDelete = _paraContext.Subscriptions.Where(s => s.Year == id).FirstOrDefault();

            subscriptionToSoftDelete.IsActive = false;

            _paraContext.Subscriptions.Update(subscriptionToSoftDelete);
            _paraContext.SaveChanges();
        }
    }
}
