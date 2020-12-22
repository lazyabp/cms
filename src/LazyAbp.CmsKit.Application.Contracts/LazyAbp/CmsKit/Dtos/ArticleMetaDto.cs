using System;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.CmsKit.Dtos
{
    [Serializable]
    public class ArticleMetaDto : EntityDto<Guid>
    {
        public Guid ArticleId { get; set; }

        public string MetaTitle { get; set; }

        public string Keywords { get; set; }

        public string MetaContent { get; set; }
    }
}