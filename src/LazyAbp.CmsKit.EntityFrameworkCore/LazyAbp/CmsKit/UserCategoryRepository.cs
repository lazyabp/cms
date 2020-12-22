using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using LazyAbp.CmsKit.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace LazyAbp.CmsKit
{
    public class UserCategoryRepository : EfCoreRepository<ICmsKitDbContext, UserCategory, Guid>, IUserCategoryRepository
    {
        public UserCategoryRepository(IDbContextProvider<ICmsKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<UserCategory>> GetUserCategoriesByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await DbSet.AsNoTracking()
                .Where(q => q.UserId == userId)
                .ToListAsync(GetCancellationToken());
        }

        public async Task<long> GetCountAsync(
            Guid? userId = null, 
            string filter = null, 
            CancellationToken cancellationToken = default
            )
        {
            var query = GetListQuery(userId, filter);

            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<UserCategory>> GetListAsync(
            int maxResultCount = 10, 
            int skipCount = 0, 
            string sorting = null, 
            Guid? userId = null, 
            string filter = null, 
            CancellationToken cancellationToken = default
            )
        {
            var query = GetListQuery(userId, filter);

            var list = await query.OrderBy(sorting ?? "creationTime desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));

            return list;
        }

        protected IQueryable<UserCategory> GetListQuery(Guid? userId = null, string filter = null)
        {
            return DbSet
                .AsNoTracking()
                .WhereIf(userId.HasValue, e => false || e.UserId == userId)
                .WhereIf(!string.IsNullOrEmpty(filter),
                    e => false
                    || e.Name.Contains(filter)
                );
        }
    }
}