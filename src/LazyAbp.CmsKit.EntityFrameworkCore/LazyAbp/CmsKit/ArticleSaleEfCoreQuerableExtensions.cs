using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.CmsKit
{
    public static class ArticleSaleEfCoreQueryableExtensions
    {
        public static IQueryable<ArticleSale> IncludeDetails(this IQueryable<ArticleSale> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                 .Include(x => x.Article);
        }
    }
}