using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.CmsKit
{
    public static class ArticleCategoryEfCoreQueryableExtensions
    {
        public static IQueryable<ArticleCategory> IncludeDetails(this IQueryable<ArticleCategory> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                // .Include(x => x.xxx) // TODO: AbpHelper generated
                ;
        }
    }
}