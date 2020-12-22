using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.CmsKit
{
    public static class ArticleLikeEfCoreQueryableExtensions
    {
        public static IQueryable<ArticleLike> IncludeDetails(this IQueryable<ArticleLike> queryable, bool include = true)
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