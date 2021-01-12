using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace LazyAbp.CmsKit
{
    public class ArticleSale : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; }

        public Guid UserId { get; protected set; }

        public Guid ArticleId { get; protected set; }

        public decimal SalePrice { get; protected set; }

        public string ArticleTitle { get; protected set; }

        public bool IsPaid { get; protected set; }

        public DateTime? PaidTime { get; protected set; }

        public Article Article { get; set; }

        protected ArticleSale()
        {
        }

        public ArticleSale(
            Guid id,
            Guid? tenantId,
            Guid userId, 
            Guid articleId, 
            decimal salePrice, 
            string articleTitle
        ) : base(id)
        {
            TenantId = tenantId;
            UserId = userId;
            ArticleId = articleId;
            SalePrice = salePrice;
            ArticleTitle = articleTitle;
            IsPaid = false;
        }

        public void SetAsPaid(DateTime paidTime)
        {
            IsPaid = true;
            PaidTime = paidTime;
        }
    }
}
