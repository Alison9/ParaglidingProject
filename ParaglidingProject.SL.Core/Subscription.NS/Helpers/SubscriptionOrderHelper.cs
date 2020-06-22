using System;
using System.Linq;

namespace ParaglidingProject.SL.Core.Subscription.NS.Helpers
{
	public enum SubscriptionSorts
	{
		noSubscriptionOrder = 0,
		YearAsc = 1,
		YearDesc = 2,
		AmountAsc = 3,
		AmountDesc = 4,
		TotalAmount = 5,
		TotalPayments = 6
	}
	public static class SubscriptionOrderHelper
	{
		public static IQueryable<Models.Subscription> SubscriptionSortBy(this IQueryable<Models.Subscription> subscriptions, SubscriptionSorts sortBy )
		{
			switch(sortBy)
			{
				case SubscriptionSorts.noSubscriptionOrder:
					return subscriptions;
				case SubscriptionSorts.YearAsc:
					return subscriptions.OrderBy(s => s.Year);
				case SubscriptionSorts.YearDesc:
					return subscriptions.OrderByDescending(s => s.Year);
				case SubscriptionSorts.AmountAsc:
					return subscriptions.OrderBy( s => s.SubscriptionAmount);
				case SubscriptionSorts.AmountDesc:
					return subscriptions.OrderByDescending(s => s.SubscriptionAmount);
				case SubscriptionSorts.TotalAmount:
					return subscriptions.OrderByDescending(s => s.SubscriptionPayments.Sum(sp => sp.Subscription.SubscriptionAmount));
				case SubscriptionSorts.TotalPayments:
					return subscriptions.OrderByDescending(s => s.SubscriptionPayments.Count());
				default:
					throw new ArgumentOutOfRangeException(nameof(sortBy), sortBy, null);
			};
			

		}
	}
}