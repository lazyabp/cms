using System;
using LazyAbp.CmsKit.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace LazyAbp.CmsKit
{
    public class ArticleCategoryRepository : EfCoreRepository<ICmsKitDbContext, ArticleCategory>, IArticleCategoryRepository
    {
        public ArticleCategoryRepository(IDbContextProvider<ICmsKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}