using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Lazy.Abp.Cms
{
    public static class ArticleEfCoreQueryableExtensions
    {
        public static IQueryable<Article> IncludeDetails(this IQueryable<Article> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                 .Include(x => x.Pictures)
                 .Include(x => x.Contents)
                 .Include(x => x.Categories)
                 .Include(x => x.Tags);
        }
    }
}