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

namespace Lazy.Abp.Cms.ArticleLikes
{
    public class ArticleLikeRepository : EfCoreRepository<ICmsDbContext, ArticleLike, Guid>, IArticleLikeRepository
    {
        public ArticleLikeRepository(IDbContextProvider<ICmsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<ArticleLike>> WithDetailsAsync()
        {
            return (await base.WithDetailsAsync())
                .Include(q => q.Article);
        }

        public async Task CreateAsync(
            Guid? tenantId,
            Guid userId, 
            Guid articleId, 
            bool like, 
            CancellationToken cancellationToken = default
        )
        {
            var result = await (await GetQueryableAsync())
                .Where(q => q.CreatorId == userId && q.ArticleId == articleId)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));

            if (null == result)
            {
                await InsertAsync(new ArticleLike(GuidGenerator.Create(), tenantId, articleId, like));
            }
        }

        public async Task RemoveAsync(
            Guid userId,
            Guid articleId,
            CancellationToken cancellationToken = default
        )
        {
            var result = await (await GetQueryableAsync())
                .AsNoTracking()
                .Where(q => q.CreatorId == userId && q.ArticleId == articleId)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));

            if (null != result)
            {
                await DeleteAsync(result, cancellationToken: GetCancellationToken(cancellationToken));
            }
        }

        public async Task<long> GetCountAsync(
            Guid? userId = null,
            Guid? articleId = null, 
            bool? likeOrDislike = null, 
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, articleId, likeOrDislike, filter);

            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<ArticleLike>> GetListAsync(
            int maxResultCount = 10, 
            int skipCount = 0, 
            string sorting = null, 
            Guid? userId = null, 
            Guid? articleId = null, 
            bool? likeOrDislike = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, articleId, likeOrDislike, filter);
            
            var list = await query.OrderBy(sorting ?? "creationTime desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));

            return list;
        }

        protected async Task<IQueryable<ArticleLike>> GetListQuery(
            Guid? userId = null,
            Guid? articleId = null,
            bool? likeOrDislike = null,
            string filter = null
        )
        {
            return (await GetQueryableAsync())
                .Include(q => q.Article)
                .WhereIf(userId.HasValue, e => e.CreatorId == userId.Value)
                .WhereIf(articleId.HasValue, e => e.ArticleId == articleId.Value)
                .WhereIf(likeOrDislike.HasValue, e => e.LikeOrDislike == likeOrDislike.Value)
                .WhereIf(!string.IsNullOrEmpty(filter),
                    e => false
                    || e.Article.Title.Contains(filter)
                    || e.Article.Description.Contains(filter)
                );
        }
    }
}