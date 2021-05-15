using System;
using Lazy.Abp.Cms.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.Cms
{
    public class ArticleCategoryRepository : EfCoreRepository<ICmsDbContext, ArticleCategory>, IArticleCategoryRepository
    {
        public ArticleCategoryRepository(IDbContextProvider<ICmsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}