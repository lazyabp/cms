using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Cms.Articles.Dtos
{
    [Serializable]
    public class ArticleMetaDto : EntityDto
    {
        public Guid ArticleId { get; set; }

        public string MetaTitle { get; set; }

        public string Keywords { get; set; }

        public string MetaDescription { get; set; }
    }
}