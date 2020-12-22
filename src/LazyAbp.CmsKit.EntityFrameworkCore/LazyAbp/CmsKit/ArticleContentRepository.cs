using System;
using LazyAbp.CmsKit.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace LazyAbp.CmsKit
{
    public class ArticleContentRepository : EfCoreRepository<ICmsKitDbContext, ArticleContent>, IArticleContentRepository
    {
        public ArticleContentRepository(IDbContextProvider<ICmsKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}