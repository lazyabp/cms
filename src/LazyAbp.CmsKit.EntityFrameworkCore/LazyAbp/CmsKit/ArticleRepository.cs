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
    public class ArticleRepository : EfCoreRepository<ICmsKitDbContext, Article, Guid>, IArticleRepository
    {
        private readonly IArticleTagRepository _articleTagRepository;

        public ArticleRepository(IDbContextProvider<ICmsKitDbContext> dbContextProvider, 
            IArticleTagRepository articleTagRepository) : base(dbContextProvider)
        {
            _articleTagRepository = articleTagRepository;
        }

        public async Task<Article> GetByIdAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            return await DbSet.IncludeDetails(includeDetails)
                .Where(q => q.Id == id)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountByTagAsync(Guid tagId, CancellationToken cancellationToken = default)
        {
            var query = GetListByTagQuery(tagId);

            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountAsync(
            Guid? userId = null,
            bool? hasFile = null,
            bool? hasVideo = null,
            bool? isFree = null,
            bool? isActive = null,
            AuditStatus? status = null,
            Guid? userCategoryId = null,
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            string filter = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        )
        {
            var query = GetListQuery(userId, hasFile, hasVideo, isFree, isActive, status, userCategoryId, createdAfter, createdBefore, filter, includeDetails);

            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Article>> GetListAsync(
            Guid? userId = null,
            bool? hasFile = null,
            bool? hasVideo = null,
            bool? isFree = null,
            bool? isActive = null,
            AuditStatus? status = null,
            Guid? userCategoryId = null,
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            string filter = null,
            bool includeDetails = false,
            int maxResultCount = 10,
            int skipCount = 0,
            string sorting = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = GetListQuery(userId, hasFile, hasVideo, isFree, isActive, status, userCategoryId, createdAfter, createdBefore, filter, includeDetails);

            var list = await query.OrderBy(sorting ?? "creationTime desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));

            return list;
        }

        public async Task<List<Article>> GetListByTagAsync(
            Guid tagId,
            bool? isActive = null,
            AuditStatus? status = null,
            int maxResultCount = 10,
            int skipCount = 0,
            string sorting = null,
            CancellationToken cancellationToken = default)
        {
            var query = GetListByTagQuery(tagId, isActive, status);

            var list = await query.OrderBy(sorting ?? "creationTime desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));

            return list;
        }

        protected IQueryable<Article> GetListQuery(
            Guid? userId = null,
            bool? hasFile = null,
            bool? hasVideo = null,
            bool? isFree = null,
            bool? isActive = null,
            AuditStatus? status = null,
            Guid? userCategoryId = null,
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            string filter = null,
            bool includeDetails = false
        )
        {
            return DbSet
                .IncludeDetails(includeDetails)
                .WhereIf(userId.HasValue, e => e.UserId == userId)
                .WhereIf(hasFile.HasValue, e => !string.IsNullOrEmpty(e.File))
                .WhereIf(hasVideo.HasValue, e => !string.IsNullOrEmpty(e.Video))
                .WhereIf(isFree.HasValue, e => e.IsFree == isFree)
                .WhereIf(isActive.HasValue, e => e.IsActive == isActive)
                .WhereIf(status.HasValue, e => e.Status == status)
                .WhereIf(userCategoryId.HasValue, e => e.UserCategoryId == userCategoryId)
                .WhereIf(createdAfter.HasValue, e => e.CreationTime >= createdAfter)
                .WhereIf(createdBefore.HasValue, e => e.CreationTime <= createdBefore)
                .WhereIf(!string.IsNullOrEmpty(filter),
                    e => false
                    || e.Title.Contains(filter)
                    || e.Descritpion.Contains(filter)
                );
        }

        protected IQueryable<Article> GetListByTagQuery(
            Guid tagId,
            bool? isActive = null,
            AuditStatus? status = null
        )
        {
            var query = from a in DbSet.AsQueryable()
                            .WhereIf(isActive.HasValue, e => false || e.IsActive == isActive)
                            .WhereIf(status.HasValue, e => false || e.Status == status)
                        join t in _articleTagRepository.AsQueryable().Where(q => q.TagId == tagId) on a.Id equals t.ArticleId
                        select a;

            return query;
        }
    }
}