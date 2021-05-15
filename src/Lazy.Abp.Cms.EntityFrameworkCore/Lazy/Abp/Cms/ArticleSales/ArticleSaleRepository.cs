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

namespace Lazy.Abp.Cms
{
    public class ArticleSaleRepository : EfCoreRepository<ICmsDbContext, ArticleSale, Guid>, IArticleSaleRepository
    {
        public ArticleSaleRepository(IDbContextProvider<ICmsDbContext> dbContextProvider) : base(dbContextProvider)
        {
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
            bool? isPaid = null,
            DateTime? paidAfther = null,
            DateTime? paidBefore = null,
            string filter = null, 
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, articleId, isPaid, paidAfther, paidBefore, filter);

            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<ArticleSale>> GetListAsync(
            int maxResultCount = 10, 
            int skipCount = 0, 
            string sorting = null, 
            Guid? userId = null,
            Guid? articleId = null, 
            bool? isPaid = null, 
            DateTime? paidAfther = null, 
            DateTime? paidBefore = null, 
            string filter = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, articleId, isPaid, paidAfther, paidBefore, filter);
            
            var list = await query.OrderBy(sorting ?? "creationTime desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));

            return list;
        }

        protected async Task<IQueryable<ArticleSale>> GetListQuery(
            Guid? userId = null,
            Guid? articleId = null,
            bool? isPaid = null,
            DateTime? paidAfther = null,
            DateTime? paidBefore = null,
            string filter = null,
            bool includeDetails = false
        )
        {
            return (await GetQueryableAsync())
                .IncludeDetails(includeDetails)
                .WhereIf(userId.HasValue, e => e.UserId == userId.Value)
                .WhereIf(articleId.HasValue, e => e.ArticleId == articleId.Value)
                .WhereIf(isPaid.HasValue, e => e.IsPaid == isPaid.Value)
                .WhereIf(paidAfther.HasValue, e => e.PaidTime >= paidAfther.Value)
                .WhereIf(paidBefore.HasValue, e => e.PaidTime <= paidBefore.Value)
                .WhereIf(!string.IsNullOrEmpty(filter),
                    e => false
                    || e.ArticleTitle.Contains(filter)
                );
        }
    }
}