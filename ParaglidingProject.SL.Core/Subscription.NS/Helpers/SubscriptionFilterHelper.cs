using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.Subscription.NS.Helpers
{
    public enum SubscriptionFilters
    {
        NoFilter = 0,
        AmountFilter = 1,
        AmountMaxFilter = 2,
        AmountMinFilter = 3
    }

    public static class SubscriptionFilter
    {
        public static IQueryable<Models.Subscription> FilterSubscriptionBy(this IQueryable<Models.Subscription> subscription, SubscriptionFilters filterBy, decimal amountTrigger)
        {
            switch (filterBy)
            {
                case SubscriptionFilters.NoFilter:
                    return subscription;
                case SubscriptionFilters.AmountFilter:
                    return subscription.Where(s => s.SubscriptionAmount > 0 );
                case SubscriptionFilters.AmountMaxFilter:
                    return subscription.Where(s => s.SubscriptionAmount <= amountTrigger);
                case SubscriptionFilters.AmountMinFilter:
                    return subscription.Where(s => s.SubscriptionAmount >= amountTrigger);
                default:
                    throw new ArgumentOutOfRangeException
                        (nameof(filterBy), filterBy, null);
            }
        }
    }


}
