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

namespace Lazy.Abp.Cms.Articles
{
    public class ArticleRepository : EfCoreRepository<ICmsDbContext, Article, Guid>, IArticleRepository
    {
        public ArticleRepository(IDbContextProvider<ICmsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<Article>> WithDetailsAsync()
        {
            return (await base.WithDetailsAsync())
                .Include(q => q.Meta)
                .Include(q => q.Content)
                .Include(q => q.Pictures)
                .Include(q => q.Categories)
                .Include(q => q.Tags).ThenInclude(q => q.Tag)
                .Include(q => q.Logs);
        }

        public async Task<long> GetCountByTagAsync(Guid tagId, CancellationToken cancellationToken = default)
        {
            var query = await GetListByTagQuery(tagId);

            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<Article> GetByIdAsync(Guid id, bool includeLogs = false, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync())
                .Include(q => q.Meta)
                .Include(q => q.Content)
                .Include(q => q.Pictures)
                .Include(q => q.Categories)
                .Include(q => q.Tags).ThenInclude(q => q.Tag)
                .IncludeIf(includeLogs, q => q.Logs)
                .Where(q => q.Id == id)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountAsync(
            Guid? userId = null,
            bool? hasFile = null,
            bool? hasVideo = null,
            bool? isFree = null,
            bool? isActive = null,
            AuditStatus? status = null,
            Guid? categoryId = null,
            Guid? userCategoryId = null,
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            string filter = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, hasFile, hasVideo, isFree, isActive, status, categoryId, userCategoryId, createdAfter, createdBefore, filter);

            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Article>> GetListAsync(
            Guid? userId = null,
            bool? hasFile = null,
            bool? hasVideo = null,
            bool? isFree = null,
            bool? isActive = null,
            AuditStatus? status = null,
            Guid? categoryId = null,
            Guid? userCategoryId = null,
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            string filter = null,
            int maxResultCount = 10,
            int skipCount = 0,
            string sorting = null,
            CancellationToken cancellationToken = default
        )
        {
            var query = await GetListQuery(userId, hasFile, hasVideo, isFree, isActive, status, categoryId, userCategoryId, createdAfter, createdBefore, filter);

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
            var query = await GetListByTagQuery(tagId, isActive, status);

            var list = await query.OrderBy(sorting ?? "creationTime desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));

            return list;
        }

        protected async Task<IQueryable<Article>> GetListQuery(
            Guid? userId = null,
            bool? hasFile = null,
            bool? hasVideo = null,
            bool? isFree = null,
            bool? isActive = null,
            AuditStatus? status = null,
            Guid? categoryId = null,
            Guid? userCategoryId = null,
            DateTime? createdAfter = null,
            DateTime? createdBefore = null,
            string filter = null,
            bool includeDetails = false
        )
        {
            return (await GetQueryableAsync())
                .WhereIf(userId.HasValue, e => e.CreatorId == userId)
                .WhereIf(hasFile.HasValue, e => !string.IsNullOrEmpty(e.File))
                .WhereIf(hasVideo.HasValue, e => !string.IsNullOrEmpty(e.Video))
                .WhereIf(isFree.HasValue, e => e.IsFree == isFree)
                .WhereIf(isActive.HasValue, e => e.IsActive == isActive)
                .WhereIf(status.HasValue, e => e.Status == status)
                .WhereIf(categoryId.HasValue, e => e.Categories.Any(x => x.CategoryId == categoryId))
                .WhereIf(userCategoryId.HasValue, e => e.UserCategoryId == userCategoryId)
                .WhereIf(createdAfter.HasValue, e => e.CreationTime >= createdAfter)
                .WhereIf(createdBefore.HasValue, e => e.CreationTime <= createdBefore)
                .WhereIf(!string.IsNullOrEmpty(filter),
                    e => false
                    || e.Title.Contains(filter)
                    || e.Descritpion.Contains(filter)
                );
        }

        protected async Task<IQueryable<Article>> GetListByTagQuery(
            Guid tagId,
            bool? isActive = null,
            AuditStatus? status = null
        )
        {
            var context = await GetDbContextAsync();

            var query = from a in context.Articles
                            .WhereIf(isActive.HasValue, e => false || e.IsActive == isActive)
                            .WhereIf(status.HasValue, e => false || e.Status == status)
                        join t in context.ArticleTags
                            .Where(q => q.TagId == tagId) 
                        on a.Id equals t.ArticleId
                        select a;

            return query;
        }
    }
}