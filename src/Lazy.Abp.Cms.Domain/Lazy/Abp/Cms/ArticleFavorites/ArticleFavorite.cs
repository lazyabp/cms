using Lazy.Abp.Cms.Articles;
using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lazy.Abp.Cms.ArticleFavorites
{
    public class ArticleFavorite : CreationAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; }

        public Guid ArticleId { get; protected set; }

        public virtual Article Article { get; set; }

        protected ArticleFavorite()
        {
        }

        public ArticleFavorite(
            Guid id,
            Guid? tenantId,
            Guid articleId
        ) : base(id)
        {
            TenantId = tenantId;
            ArticleId = articleId;
        }
    }
}
