using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Cms.ArticleSales.Dtos
{
    public class ArticleSalesListRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? UserId { get; set; }

        public Guid? ArticleId { get; set; }

        public decimal? MinPaidAmount { get; set; }

        public decimal? MaxPaidAmount { get; set; }

        public DateTime? CreationAfther { get; set; }

        public DateTime? CreationBefore { get; set; }

        public string Filter { get; set; }
    }
}
