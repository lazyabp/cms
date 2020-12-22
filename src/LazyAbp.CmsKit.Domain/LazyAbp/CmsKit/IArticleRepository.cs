using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace LazyAbp.CmsKit
{
    public interface IArticleRepository : IRepository<Article, Guid>
    {
        Task<Article> GetByIdAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default);

        Task<long> GetCountByTagAsync(Guid tagId, CancellationToken cancellationToken = default);

        Task<List<Article>> GetListByTagAsync(
            Guid tagId,
            bool? isActive = null,
            AuditStatus? status = null,
            int maxResultCount = 10,
            int skipCount = 0,
            string sorting = null,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            Guid? userId = null,
            bool? hasFile = null,
            bool? hasVideo = null,
            bool? isFree = null,
            bool? isActive = null,
            AuditStatus? status = null,
            Guid? userCategoryId = null,
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            string filter = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        );

        Task<List<Article>> GetListAsync(
            Guid? userId = null,
            bool? hasFile = null,
            bool? hasVideo = null,
            bool? isFree = null,
            bool? isActive = null,
            AuditStatus? status = null,
            Guid? userCategoryId = null,
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            string filter = null,
            bool includeDetails = false,
            int maxResultCount = 10,
            int skipCount = 0,
            string sorting = null,
            CancellationToken cancellationToken = default
        );

    }
}