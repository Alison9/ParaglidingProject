using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParaglidingProject.SL.Core.Subscription.NS.Helpers
{
    public enum SubscriptionSearches
    {
        NoSearch = 0,
        Year = 1,
        Amount = 2
    }
    public static class SubscriptionSeachHelper
    {
        public static IQueryable<Models.Subscription> SearchSubscriptionBy(this IQueryable<Models.Subscription> subscriptions, SubscriptionSearches pSearchBy,decimal pSearchinValue)
        {
            switch (pSearchBy)
            {
                case SubscriptionSearches.NoSearch:
                    return subscriptions;
                case SubscriptionSearches.Year:
                    return subscriptions.Where(s => s.Year == pSearchinValue);
                case SubscriptionSearches.Amount:
                    return subscriptions.Where(s => s.SubscriptionAmount == pSearchinValue);
                default:
                    throw new ArgumentOutOfRangeException
                        (nameof(pSearchBy), pSearchBy, null);
            }
        }
    }
}
