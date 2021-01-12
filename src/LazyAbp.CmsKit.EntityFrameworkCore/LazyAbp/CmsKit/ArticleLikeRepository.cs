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
    public class ArticleLikeRepository : EfCoreRepository<ICmsKitDbContext, ArticleLike, Guid>, IArticleLikeRepository
    {
        public ArticleLikeRepository(IDbContextProvider<ICmsKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task CreateAsync(
            Guid? tenantId,
            Guid userId, 
            Guid articleId, 
            bool like, 
            CancellationToken cancellationToken = default)
        {
            var result = await DbSet.AsNoTracking()
                    .Where(q => q.UserId == userId && q.ArticleId == articleId)
                    .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));

            if (result != null)
                throw new Exception("HasBeenSetLike");

            await InsertAsync(new ArticleLike(GuidGenerator.Create(), tenantId, userId, articleId, like),
                    cancellationToken: GetCancellationToken(cancellationToken));
        }

        public async Task RemoveAsync(
            Guid userId, 
            Guid articleId, 
            bool like, 
            CancellationToken cancellationToken = default)
        {
            var result = await DbSet.AsNoTracking()
                    .Where(q => q.UserId == userId && q.ArticleId == articleId)
                    .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));

            if (result == null)
                throw new Exception("HasBeenRemovedLike");

            if (result.LikeOrDislike != like)
                throw new Exception("InvalidOperation");

            await DeleteAsync(result, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountAsync(
            Guid? userId = null,
            Guid? articleId = null, 
            bool? likeOrDislike = null, 
            string filter = null, 
            bool includeDetails = false, 
            CancellationToken cancellationToken = default
            )
        {
            var query = GetListQuery(userId, articleId, likeOrDislike, filter, includeDetails);

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
            bool includeDetails = false, 
            CancellationToken cancellationToken = default
            )
        {
            var query = GetListQuery(userId, articleId, likeOrDislike, filter, includeDetails);
            
            var list = await query.OrderBy(sorting ?? "creationTime desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));

            return list;
        }

        protected IQueryable<ArticleLike> GetListQuery(
            Guid? userId = null,
            Guid? articleId = null,
            bool? likeOrDislike = null,
            string filter = null,
            bool includeDetails = false
            )
        {
            return DbSet
                .IncludeDetails(includeDetails)
                .WhereIf(userId.HasValue, e => e.UserId == userId.Value)
                .WhereIf(articleId.HasValue, e => e.ArticleId == articleId.Value)
                .WhereIf(likeOrDislike.HasValue, e => e.LikeOrDislike == likeOrDislike.Value)
                .WhereIf(!string.IsNullOrEmpty(filter),
                    e => false
                    || e.Article.Title.Contains(filter)
                    || e.Article.Descritpion.Contains(filter)
                );
        }
    }
}