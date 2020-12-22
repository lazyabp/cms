using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.CmsKit
{
    public static class ArticleTagEfCoreQueryableExtensions
    {
        public static IQueryable<ArticleTag> IncludeDetails(this IQueryable<ArticleTag> queryable, bool include = true)
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