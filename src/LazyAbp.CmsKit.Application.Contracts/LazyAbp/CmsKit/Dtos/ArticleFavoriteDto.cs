using System;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.CmsKit.Dtos
{
    [Serializable]
    public class ArticleFavoriteDto : CreationAuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }

        public Guid ArticleId { get; set; }

        public virtual ArticleViewDto Article { get; set; }
    }
}