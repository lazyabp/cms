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

namespace Lazy.Abp.Cms.ArticleComments
{
    public class ArticleCommentRepository : EfCoreRepository<ICmsDbContext, ArticleComment, Guid>, IArticleCommentRepository
    {
        public ArticleCommentRepository(IDbContextProvider<ICmsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<ArticleComment>> WithDetailsAsync()
        {
            return (await base.WithDetailsAsync())
                .Include(q => q.Article);
        }

        public async Task<long> GetCountAsync(
            Guid? userId = null, 
            Guid? articleId = null, 
            Guid? parentId = null, 
            AuditStatus? status = null, 
            string filter = null, 
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, articleId, parentId, status, filter);

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
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, articleId, parentId, status, filter);
            
            var list = await query.OrderBy(sorting ?? "creationTime desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));

            return list;
        }

        protected async Task<IQueryable<ArticleComment>> GetListQuery(
            Guid? userId = null,
            Guid? articleId = null,
            Guid? parentId = null,
            AuditStatus? status = null,
            string filter = null
        )
        {
            return (await GetQueryableAsync())
                .Include(q => q.Article)
                .WhereIf(userId.HasValue, e => e.CreatorId == userId.Value)
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