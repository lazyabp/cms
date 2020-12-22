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
    public class SinglePageRepository : EfCoreRepository<ICmsKitDbContext, SinglePage, Guid>, ISinglePageRepository
    {
        public SinglePageRepository(IDbContextProvider<ICmsKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<SinglePage> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(q => q.Name == name)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountAsync(
            DateTime? createdAfter = null, 
            DateTime? createdBefore = null, 
            string filter = null, 
            CancellationToken cancellationToken = default
            )
        {
            var query = GetListQuery(createdAfter, createdBefore, filter);

            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<SinglePage>> GetListAsync(
            int maxResultCount = 10, 
            int skipCount = 0, 
            string sorting = null, 
            DateTime? createdAfter = null, 
            DateTime? createdBefore = null, 
            string filter = null, 
            CancellationToken cancellationToken = default
            )
        {
            var query = GetListQuery(createdAfter, createdBefore, filter);

            var list = await query.OrderBy(sorting ?? "creationTime desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));

            return list;
        }

        protected IQueryable<SinglePage> GetListQuery(
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            string filter = null
            )
        {
            return DbSet
                .WhereIf(createdAfter.HasValue, e => e.CreationTime >= createdAfter.Value)
                .WhereIf(createdBefore.HasValue, e => e.CreationTime <= createdBefore.Value)
                .WhereIf(!string.IsNullOrEmpty(filter),
                    e => false
                    || e.Title.Contains(filter)
                    || e.FullDescription.Contains(filter)
                );
        }
    }
}