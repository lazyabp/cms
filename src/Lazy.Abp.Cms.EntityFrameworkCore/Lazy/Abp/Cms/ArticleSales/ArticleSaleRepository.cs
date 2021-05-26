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

namespace Lazy.Abp.Cms.ArticleSales
{
    public class ArticleSaleRepository : EfCoreRepository<ICmsDbContext, ArticleSale, Guid>, IArticleSaleRepository
    {
        public ArticleSaleRepository(IDbContextProvider<ICmsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<ArticleSale>> WithDetailsAsync()
        {
            return (await base.WithDetailsAsync())
                .Include(q => q.Article);
        }

        public async Task<ArticleSale> GetByUserAndArticleAsync(
            Guid userId, 
            Guid articleId, 
            CancellationToken cancellationToken = default
        )
        {
            return await (await GetQueryableAsync())
                .AsNoTracking()
                .Where(q => q.UserId == userId && q.ArticleId == articleId)
                .FirstOrDefaultAsync(GetCancellationToken());
        }

        public async Task<List<ArticleSale>> GetByUserAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync())
                .AsNoTracking()
                .Where(q => q.UserId == userId)
                .ToListAsync(GetCancellationToken());
        }

        public async Task<long> GetCountAsync(
            Guid? userId = null,
            Guid? articleId = null,
            decimal? minPaidAmount = null,
            decimal? maxPaidAmount = null,
            DateTime? creationAfther = null,
            DateTime? creationBefore = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, articleId, minPaidAmount, maxPaidAmount, creationAfther, creationBefore, filter);

            return await query
                .LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<ArticleSale>> GetListAsync(
            int maxResultCount = 10,
            int skipCount = 0,
            string sorting = null,
            Guid? userId = null,
            Guid? articleId = null,
            decimal? minPaidAmount = null,
            decimal? maxPaidAmount = null,
            DateTime? creationAfther = null,
            DateTime? creationBefore = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, articleId, minPaidAmount, maxPaidAmount, creationAfther, creationBefore, filter);

            var list = await query.OrderBy(sorting ?? "creationTime desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));

            return list;
        }

        protected async Task<IQueryable<ArticleSale>> GetListQuery(
            Guid? userId = null,
            Guid? articleId = null,
            decimal? minPaidAmount = null,
            decimal? maxPaidAmount = null,
            DateTime? creationAfther = null,
            DateTime? creationBefore = null,
            string filter = null
        )
        {
            return (await GetQueryableAsync())
                .Include(q => q.Article)
                .WhereIf(userId.HasValue, e => e.UserId == userId)
                .WhereIf(articleId.HasValue, e => e.ArticleId == articleId)
                .WhereIf(minPaidAmount.HasValue, e => e.PaidAmount >= minPaidAmount)
                .WhereIf(maxPaidAmount.HasValue, e => e.PaidAmount <= maxPaidAmount)
                .WhereIf(creationAfther.HasValue, e => e.CreationTime >= creationAfther.Value.Date)
                .WhereIf(creationBefore.HasValue, e => e.CreationTime < creationBefore.Value.AddDays(1).Date)
                .WhereIf(!string.IsNullOrEmpty(filter),
                    e => false
                    || e.OrderId.Contains(filter)
                    || e.Article.Title.Contains(filter)
                );
        }
    }
}