using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace LazyAbp.CmsKit
{
    public interface IArticleTagRepository : IRepository<ArticleTag>
    {
        //IQueryable<ArticleTag> AsQueryable();
    }
}
