using System;
using Lazy.Abp.Cms.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.Cms.Articles
{
    public class ArticleContentRepository : EfCoreRepository<ICmsDbContext, ArticleContent>, IArticleContentRepository
    {
        public ArticleContentRepository(IDbContextProvider<ICmsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}