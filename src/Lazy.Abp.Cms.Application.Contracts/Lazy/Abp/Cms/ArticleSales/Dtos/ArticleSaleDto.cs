using Lazy.Abp.Cms.Articles.Dtos;
using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Cms.ArticleSales.Dtos
{
    [Serializable]
    public class ArticleSaleDto : FullAuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }

        public Guid ArticleId { get; set; }

        public string OrderId { get; set; }

        public decimal PaidAmount { get; set; }

        public ArticleDto Article { get; set; }
    }
}