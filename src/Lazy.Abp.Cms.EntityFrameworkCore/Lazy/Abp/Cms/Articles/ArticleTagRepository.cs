using System;
using System.Linq;
using Lazy.Abp.Cms.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.Cms
{
    public class ArticleTagRepository : EfCoreRepository<ICmsDbContext, ArticleTag>, IArticleTagRepository
    {
        public ArticleTagRepository(IDbContextProvider<ICmsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        //public IQueryable<ArticleTag> AsQueryable()
        //{
        //    return DbSet.AsQueryable();
        //}
    }
}