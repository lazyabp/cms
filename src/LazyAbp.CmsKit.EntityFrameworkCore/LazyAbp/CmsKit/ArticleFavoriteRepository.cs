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
    public class ArticleFavoriteRepository : EfCoreRepository<ICmsKitDbContext, ArticleFavorite, Guid>, IArticleFavoriteRepository
    {
        public ArticleFavoriteRepository(IDbContextProvider<ICmsKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task CreateAsync(
            Guid userId, 
            Guid articleId, 
            CancellationToken cancellationToken = default)
        {
            var result = await DbSet.AsNoTracking()
                    .Where(q => q.UserId == userId && q.ArticleId == articleId)
                    .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));

            if (result != null)
                throw new Exception("HasBeenAddedToFavorite");

            await InsertAsync(new ArticleFavorite(GuidGenerator.Create(), userId, articleId),
                    cancellationToken: GetCancellationToken(cancellationToken));
        }

        public async Task RemoveAsync(
            Guid userId, 
            Guid articleId, 
            CancellationToken cancellationToken = default)
        {
            var result = await DbSet.AsNoTracking()
                    .Where(q => q.UserId == userId && q.ArticleId == articleId)
                    .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));

            if (result == null)
                throw new Exception("HasBeenRemovedFromFavorite");

            await DeleteAsync(result, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountAsync(
            Guid? userId = null, 
            Guid? articleId = null, 
            string filter = null, 
            bool includeDetails = false, 
            CancellationToken cancellationToken = default
            )
        {
            var query = GetListQuery(userId, articleId, filter, includeDetails);

            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<ArticleFavorite>> GetListAsync(
            int maxResultCount = 10, 
            int skipCount = 0, 
            string sorting = null, 
            Guid? userId = null, 
            Guid? articleId = null, 
            string filter = null, 
            bool includeDetails = false, 
            CancellationToken cancellationToken = default
            )
        {
            var query = GetListQuery(userId, articleId, filter, includeDetails);

            var list = await query.OrderBy(sorting ?? "creationTime desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));

            return list;
        }

        protected IQueryable<ArticleFavorite> GetListQuery(
            Guid? userId = null,
            Guid? articleId = null,
            string filter = null,
            bool includeDetails = false
            )
        {
            return DbSet
                .IncludeDetails(includeDetails)
                .WhereIf(userId.HasValue, e => e.UserId == userId.Value)
                .WhereIf(articleId.HasValue, e => e.ArticleId == articleId.Value)
                .WhereIf(!string.IsNullOrEmpty(filter),
                    e => false
                    || e.Article.Title.Contains(filter)
                    || e.Article.Descritpion.Contains(filter)
                );
        }
    }
}