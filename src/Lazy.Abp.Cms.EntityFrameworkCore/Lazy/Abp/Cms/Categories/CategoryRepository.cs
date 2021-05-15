using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Lazy.Abp.Cms.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.Cms.Categories
{
    public class CategoryRepository : EfCoreRepository<ICmsDbContext, Category, Guid>, ICategoryRepository
    {
        public CategoryRepository(IDbContextProvider<ICmsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Category>> GetByIdsAsync(List<Guid> ids, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync())
                .AsNoTracking()
                .Where(q => ids.Contains(q.Id))
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Category>> GetByParentIdAsync(Guid? parentId, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync())
                .AsNoTracking()
                .Where(q => q.ParentId == parentId)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Category>> GetByRootIdAsync(Guid? rootId, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync())
                .AsNoTracking()
                .Where(q => q.RootId == rootId)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountAsync(
            Guid? parentId = null,
            Guid? rootId = null,
            string filter = null, 
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(parentId, rootId, filter);

            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Category>> GetListAsync(
            int maxResultCount = 10, 
            int skipCount = 0, 
            string sorting = null, 
            Guid? parentId = null,
            Guid? rootId = null,
            string filter = null, 
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(parentId, rootId, filter);

            var list = await query.OrderBy(sorting ?? "DisplayOrder desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));

            return list;
        }

        protected async Task<IQueryable<Category>> GetListQuery(Guid? parentId = null, Guid? rootId = null, string filter = null)
        {
            return (await GetQueryableAsync())
                .AsNoTracking()
                .WhereIf(parentId.HasValue, e => false || e.ParentId == parentId)
                .WhereIf(rootId.HasValue, e => false || e.RootId == rootId)
                .WhereIf(!string.IsNullOrEmpty(filter),
                    e => false
                    || e.Name.Contains(filter)
                );
        }
    }
}