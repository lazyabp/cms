using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.Cms
{
    public interface ICategoryRepository : IRepository<Category, Guid>
    {
        Task<List<Category>> GetByParentIdAsync(Guid? parentId, CancellationToken cancellationToken = default);

        Task<List<Category>> GetByRootIdAsync(Guid? rootId, CancellationToken cancellationToken = default);

        Task<List<Category>> GetByIdsAsync(List<Guid> ids, CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            Guid? parentId = null,
            Guid? rootId = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );

        Task<List<Category>> GetListAsync(
            int maxResultCount = 10,
            int skipCount = 0,
            string sorting = null,
            Guid? parentId = null,
            Guid? rootId = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );
    }
}