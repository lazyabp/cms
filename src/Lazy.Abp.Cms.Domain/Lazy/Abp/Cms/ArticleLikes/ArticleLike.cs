using Lazy.Abp.Cms.Articles;
using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lazy.Abp.Cms.ArticleLikes
{
    public class ArticleLike : CreationAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; }

        public Guid ArticleId { get; protected set; }

        public bool LikeOrDislike { get; protected set; }

        public virtual Article Article { get; set; }

        protected ArticleLike()
        {
        }

        public ArticleLike(
            Guid id,
            Guid? tenantId,
            Guid articleId,
            bool likeOrDislike
        ) : base(id)
        {
            TenantId = tenantId;
            ArticleId = articleId;
            LikeOrDislike = likeOrDislike;
        }
    }
}
