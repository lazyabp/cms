using System;
using System.Linq;
using LazyAbp.CmsKit.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace LazyAbp.CmsKit
{
    public class ArticleTagRepository : EfCoreRepository<ICmsKitDbContext, ArticleTag>, IArticleTagRepository
    {
        public ArticleTagRepository(IDbContextProvider<ICmsKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        //public IQueryable<ArticleTag> AsQueryable()
        //{
        //    return DbSet.AsQueryable();
        //}
    }
}