using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.Cms.Tags
{
    public interface ITagRepository : IRepository<Tag, Guid>
    {
        Task<Tag> GetByNameAsync(string name, CancellationToken cancellationToken = default);

        Task<List<Tag>> GetByIdsAsync(List<Guid> ids, CancellationToken cancellationToken = default);
        
        Task<List<Tag>> GetByNamesAsync(List<string> names, CancellationToken cancellationToken = default);

        Task<List<Tag>> GetAndCreateTagsAsync(List<string> names, CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            string filter = null,
            CancellationToken cancellationToken = default
        );

        Task<List<Tag>> GetListAsync(
            int maxResultCount = 10,
            int skipCount = 0,
            string sorting = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );
    }
}