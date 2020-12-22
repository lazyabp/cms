using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using LazyAbp.CmsKit.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace LazyAbp.CmsKit
{
    public class ArticleCommentRepository : EfCoreRepository<ICmsKitDbContext, ArticleComment, Guid>, IArticleCommentRepository
    {
        public ArticleCommentRepository(IDbContextProvider<ICmsKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<long> GetCountAsync(
            Guid? userId = null, 
            Guid? articleId = null, 
            Guid? parentId = null, 
            AuditStatus? status = null, 
            string filter = null, 
            bool includeDetails = false, 
            CancellationToken cancellationToken = default
            )
        {
            var query = GetListQuery(userId, articleId, parentId, status, filter, includeDetails);

            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<ArticleComment>> GetListAsync(
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
            )
        {
            var query = GetListQuery(userId, articleId, parentId, status, filter, includeDetails);
            
            var list = await query.OrderBy(sorting ?? "creationTime desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));

            return list;
        }

        protected IQueryable<ArticleComment> GetListQuery(
            Guid? userId = null,
            Guid? articleId = null,
            Guid? parentId = null,
            AuditStatus? status = null,
            string filter = null,
            bool includeDetails = false
            )
        {
            return DbSet
                .IncludeDetails(includeDetails)
                .WhereIf(userId.HasValue, e => e.UserId == userId.Value)
                .WhereIf(articleId.HasValue, e => e.ArticleId == articleId.Value)
                .WhereIf(parentId.HasValue, e => e.ParentId == parentId.Value)
                .WhereIf(status.HasValue, e => e.Status == status.Value)
                .WhereIf(!string.IsNullOrEmpty(filter),
                    e => false
                    || e.Content.Contains(filter)
                );
        }
    }
}