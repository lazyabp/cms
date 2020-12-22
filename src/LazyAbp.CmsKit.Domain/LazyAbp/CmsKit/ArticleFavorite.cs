using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace LazyAbp.CmsKit
{
    public class ArticleFavorite : CreationAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; }

        public Guid UserId { get; protected set; }

        public Guid ArticleId { get; protected set; }

        public virtual Article Article { get; set; }

        protected ArticleFavorite()
        {
        }

        public ArticleFavorite(
            Guid id, 
            Guid userId, 
            Guid articleId
        ) : base(id)
        {
            UserId = userId;
            ArticleId = articleId;
        }
    }
}
