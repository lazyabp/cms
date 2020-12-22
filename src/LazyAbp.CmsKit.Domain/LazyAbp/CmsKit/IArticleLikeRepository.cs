using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace LazyAbp.CmsKit
{
    public interface IArticleLikeRepository : IRepository<ArticleLike, Guid>
    {
        Task CreateAsync(Guid userId, Guid articleId, bool like, CancellationToken cancellationToken = default);

        Task RemoveAsync(Guid userId, Guid articleId, bool like, CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            Guid? userId = null,
            Guid? articleId = null,
            bool? likeOrDislike = null,
            string filter = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        );

        Task<List<ArticleLike>> GetListAsync(
            int maxResultCount = 10,
            int skipCount = 0,
            string sorting = null,
            Guid? userId = null,
            Guid? articleId = null,
            bool? likeOrDislike = null,
            string filter = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        );
    }
}