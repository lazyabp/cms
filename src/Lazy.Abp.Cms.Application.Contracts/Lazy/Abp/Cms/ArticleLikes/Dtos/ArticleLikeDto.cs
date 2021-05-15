using Lazy.Abp.Cms.Articles.Dtos;
using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Cms.ArticleLikes.Dtos
{
    [Serializable]
    public class ArticleLikeDto : CreationAuditedEntityDto<Guid>
    {
        public Guid ArticleId { get; set; }

        public bool LikeOrDislike { get; set; }

        public virtual ArticleDto Article { get; set; }
    }
}