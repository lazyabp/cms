using Lazy.Abp.Cms.Articles;
using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lazy.Abp.Cms.ArticleSales
{
    public class ArticleSale : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }

        public Guid UserId { get; private set; }

        public Guid ArticleId { get; private set; }

        public string OrderId { get; private set; }

        public decimal PaidAmount { get; private set; }

        public virtual Article Article { get; set; }

        protected ArticleSale()
        {
        }

        public ArticleSale(
            Guid id,
            Guid? tenantId,
            Guid userId, 
            Guid articleId,
            string orderId,
            decimal paidAmount
        ) : base(id)
        {
            TenantId = tenantId;
            UserId = userId;
            ArticleId = articleId;
            OrderId = orderId;
            PaidAmount = paidAmount;
        }
    }
}
