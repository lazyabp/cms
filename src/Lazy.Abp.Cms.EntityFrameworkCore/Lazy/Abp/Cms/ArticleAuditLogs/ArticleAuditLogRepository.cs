using Lazy.Abp.Cms.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.Cms
{
    public class ArticleAuditLogRepository : EfCoreRepository<ICmsDbContext, ArticleAuditLog, Guid>, IArticleAuditLogRepository
    {
        public ArticleAuditLogRepository(IDbContextProvider<ICmsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<long> GetCountAsync(
            Guid? articleId = null,
            AuditStatus? status = null,
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetQuery(articleId, status, createdAfter, createdBefore, filter);

            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<ArticleAuditLog>> GetListAsync(
            Guid? articleId = null,
            AuditStatus? status = null,
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            string filter = null,
            int maxResultCount = 10,
            int skipCount = 0,
            string sorting = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetQuery(articleId, status, createdAfter, createdBefore, filter);

            return await query.OrderBy(sorting ?? "creationTime desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        protected async Task<IQueryable<ArticleAuditLog>> GetQuery(
            Guid? articleId = null,
            AuditStatus? status = null,
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            string filter = null
        )
        {
            return (await GetQueryableAsync())
                .WhereIf(articleId.HasValue, e => e.ArticleId == articleId)
                .WhereIf(status.HasValue, e => e.Status == status)
                .WhereIf(createdAfter.HasValue, e => e.CreationTime >= createdAfter)
                .WhereIf(createdBefore.HasValue, e => e.CreationTime <= createdBefore)
                .WhereIf(!string.IsNullOrEmpty(filter),
                    e => false
                    || e.Remark.Contains(filter)
                );
        }
    }
}
