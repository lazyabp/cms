using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.CmsKit
{
    public static class ArticleContentEfCoreQueryableExtensions
    {
        public static IQueryable<ArticleContent> IncludeDetails(this IQueryable<ArticleContent> queryable, bool include = true)
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