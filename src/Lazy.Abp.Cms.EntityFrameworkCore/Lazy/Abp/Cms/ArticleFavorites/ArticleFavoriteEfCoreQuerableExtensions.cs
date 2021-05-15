using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Lazy.Abp.Cms
{
    public static class ArticleFavoriteEfCoreQueryableExtensions
    {
        public static IQueryable<ArticleFavorite> IncludeDetails(this IQueryable<ArticleFavorite> queryable, bool include = true)
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