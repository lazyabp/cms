using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.Cms
{
    public interface ISinglePageRepository : IRepository<SinglePage, Guid>
    {
        Task<SinglePage> GetByNameAsync(string name, CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );

        Task<List<SinglePage>> GetListAsync(
            int maxResultCount = 10,
            int skipCount = 0,
            string sorting = null,
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );
    }
}