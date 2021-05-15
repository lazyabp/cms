using Lazy.Abp.Cms.Articles.Dtos;
using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Cms.ArticleFavorites.Dtos
{
    [Serializable]
    public class ArticleFavoriteDto : CreationAuditedEntityDto<Guid>
    {
        public Guid ArticleId { get; set; }

        public virtual ArticleDto Article { get; set; }
    }
}