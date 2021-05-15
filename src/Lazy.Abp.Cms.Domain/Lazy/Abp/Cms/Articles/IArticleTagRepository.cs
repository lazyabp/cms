using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.Cms.Articles
{
    public interface IArticleTagRepository : IRepository<ArticleTag>
    {
        //IQueryable<ArticleTag> AsQueryable();
    }
}
