using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.Cms
{
    public interface IUserCategoryRepository : IRepository<UserCategory, Guid>
    {
        Task<List<UserCategory>> GetUserCategoriesByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            Guid? userId = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );

        Task<List<UserCategory>> GetListAsync(
            int maxResultCount = 10,
            int skipCount = 0,
            string sorting = null,
            Guid? userId = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );
    }
}