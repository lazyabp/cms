using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.Cms.ArticleSales
{
    public interface IArticleSaleRepository : IRepository<ArticleSale, Guid>
    {
        Task<List<ArticleSale>> GetByUserAsync(Guid userId, CancellationToken cancellationToken = default);

        Task<ArticleSale> GetByUserAndArticleAsync(Guid userId, Guid articleId, CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            Guid? userId = null,
            Guid? articleId = null,
            decimal? minPaidAmount = null,
            decimal? maxPaidAmount = null,
            DateTime? creationAfther = null,
            DateTime? creationBefore = null,
            string filter = null,
            CancellationToken cancellationToken = default
        );

        Task<List<ArticleSale>> GetListAsync(
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
        );
    }
}
