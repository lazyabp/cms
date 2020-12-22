using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace LazyAbp.CmsKit
{
    public interface IArticleCommentRepository : IRepository<ArticleComment, Guid>
    {
        Task<long> GetCountAsync(
            Guid? userId = null,
            Guid? articleId = null,
            Guid? parentId = null,
            AuditStatus? status = null,
            string filter = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        );

        Task<List<ArticleComment>> GetListAsync(
            int maxResultCount = 10,
            int skipCount = 0,
            string sorting = null,
            Guid? userId = null,
            Guid? articleId = null,
            Guid? parentId = null,
            AuditStatus? status = null,
            string filter = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        );
    }
}