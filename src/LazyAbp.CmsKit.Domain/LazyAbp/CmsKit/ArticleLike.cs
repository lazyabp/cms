using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace LazyAbp.CmsKit
{
    public class ArticleLike : CreationAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; }

        public Guid UserId { get; protected set; }

        public Guid ArticleId { get; protected set; }

        public bool LikeOrDislike { get; protected set; }

        public virtual Article Article { get; set; }

        protected ArticleLike()
        {
        }

        public ArticleLike(
            Guid id, 
            Guid userId, 
            Guid articleId,
            bool likeOrDislike
        ) : base(id)
        {
            UserId = userId;
            ArticleId = articleId;
            LikeOrDislike = likeOrDislike;
        }
    }
}
