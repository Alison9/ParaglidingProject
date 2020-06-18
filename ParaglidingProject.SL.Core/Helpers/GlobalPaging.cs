using System;
using System.Linq;

namespace ParaglidingProject.SL.Core.Helpers
{
    public static class GlobalPaging
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, int pageStart, int pageSize)
        {
            if (pageSize == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), "pageSize cannot be zero.");
            }

            if (pageStart != 0)
            {
                query = query.Skip(pageStart * pageSize);
            }

            return query.Take(pageSize);
        }
    }
}
