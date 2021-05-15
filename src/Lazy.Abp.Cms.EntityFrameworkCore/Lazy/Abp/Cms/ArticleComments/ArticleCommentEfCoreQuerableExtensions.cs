using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Lazy.Abp.Cms
{
    public static class ArticleCommentEfCoreQueryableExtensions
    {
        public static IQueryable<ArticleComment> IncludeDetails(this IQueryable<ArticleComment> queryable, bool include = true)
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