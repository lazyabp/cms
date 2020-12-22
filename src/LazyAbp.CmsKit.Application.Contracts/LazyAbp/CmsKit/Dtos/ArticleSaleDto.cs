using System;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.CmsKit.Dtos
{
    [Serializable]
    public class ArticleSaleDto : FullAuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }

        public Guid ArticleId { get; set; }

        public decimal SalePrice { get; set; }

        public string ArticleTitle { get; set; }

        public bool IsPaid { get; set; }

        public DateTime? PaidTime { get; set; }

        public ArticleViewDto Article { get; set; }
    }
}