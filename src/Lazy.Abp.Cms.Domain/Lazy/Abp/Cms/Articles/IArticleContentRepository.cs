using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.Cms.Articles
{
    public interface IArticleContentRepository : IRepository<ArticleContent>
    {
    }
}
