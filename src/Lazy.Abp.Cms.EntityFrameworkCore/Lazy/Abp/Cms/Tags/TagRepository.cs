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

namespace Lazy.Abp.Cms
{
    public class TagRepository : EfCoreRepository<ICmsDbContext, Tag, Guid>, ITagRepository
    {
        public TagRepository(IDbContextProvider<ICmsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Tag> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync())
                .AsNoTracking()
                .Where(q => q.Name == name)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Tag>> GetByIdsAsync(List<Guid> ids, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync())
                .AsNoTracking()
                .Where(q => ids.Contains(q.Id))
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Tag>> GetByNamesAsync(List<string> names, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync()).AsNoTracking()
                .Where(q => names.Contains(q.Name))
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Tag>> GetAndCreateTagsAsync(List<string> names, CancellationToken cancellationToken = default)
        {
            var tags = await GetByNamesAsync(names, cancellationToken);

            if (tags.Count != names.Count)
            {
                foreach (var name in names)
                {
                    if (!tags.Exists(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                    {
                        var tag = await InsertAsync(new Tag(GuidGenerator.Create(), name, 0), cancellationToken: cancellationToken);

                        tags.Add(tag);
                    }
                }
            }

            return tags;
        }

        public async Task<long> GetCountAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            var query = await GetListQuery(filter);

            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Tag>> GetListAsync(
            int maxResultCount = 10, 
            int skipCount = 0, 
            string sorting = null, 
            string filter = null, 
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(filter);

            var list = await query.OrderBy(sorting ?? "hits desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));

            return list;
        }

        protected async Task<IQueryable<Tag>> GetListQuery(string filter = null)
        {
            return (await GetQueryableAsync())
                .AsNoTracking()
                .WhereIf(!string.IsNullOrEmpty(filter),
                    e => false
                    || e.Name.Contains(filter)
                );
        }
    }
}