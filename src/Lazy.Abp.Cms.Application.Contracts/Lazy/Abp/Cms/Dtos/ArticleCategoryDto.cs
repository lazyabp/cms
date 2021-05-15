using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Cms.Dtos
{
    [Serializable]
    public class ArticleCategoryDto : EntityDto
    {
        public Guid CategoryId { get; set; }

        public Guid ArticleId { get; set; }

        public CategoryViewDto Category { get; set; }
    }
}