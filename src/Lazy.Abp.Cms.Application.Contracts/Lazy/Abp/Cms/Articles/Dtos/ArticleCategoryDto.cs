using Lazy.Abp.Cms.Categories.Dtos;
using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Cms.Articles.Dtos
{
    [Serializable]
    public class ArticleCategoryDto : EntityDto
    {
        public Guid CategoryId { get; set; }

        public Guid ArticleId { get; set; }
    }
}