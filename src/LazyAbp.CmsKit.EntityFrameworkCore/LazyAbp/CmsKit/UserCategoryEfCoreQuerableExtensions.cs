using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.CmsKit
{
    public static class UserCategoryEfCoreQueryableExtensions
    {
        public static IQueryable<UserCategory> IncludeDetails(this IQueryable<UserCategory> queryable, bool include = true)
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