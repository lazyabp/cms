using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.CmsKit
{
    public static class SinglePageEfCoreQueryableExtensions
    {
        public static IQueryable<SinglePage> IncludeDetails(this IQueryable<SinglePage> queryable, bool include = true)
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