using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace LazyAbp.CmsKit
{
    public interface IArticleAuditLogRepository : IRepository<ArticleAuditLog, Guid>
    {
        Task<long> GetCountAsync(
            Guid? articleId = null,
            AuditStatus? status = null,
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );

        Task<List<ArticleAuditLog>> GetListAsync(
            Guid? articleId = null,
            AuditStatus? status = null,
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            string filter = null,
            int maxResultCount = 10,
            int skipCount = 0,
            string sorting = null,
            CancellationToken cancellationToken = default
        );
    }
}
