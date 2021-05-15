using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Cms.Dtos
{
    [Serializable]
    public class ArticleLikeDto : CreationAuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }

        public Guid ArticleId { get; set; }

        public bool LikeOrDislike { get; set; }

        public virtual ArticleDto Article { get; set; }
    }
}