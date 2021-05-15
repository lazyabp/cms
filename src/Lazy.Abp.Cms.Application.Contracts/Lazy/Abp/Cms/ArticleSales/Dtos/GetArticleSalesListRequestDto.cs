using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Cms.ArticleSales.Dtos
{
    public class GetArticleSalesListRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? UserId { get; set; }

        public Guid? ArticleId { get; set; }

        public bool? IsPaid { get; set; }

        public DateTime? PaidTimeBefore { get; set; }

        public DateTime? PaidTimeAfter { get; set; }

        public string Filter { get; set; }
    }
}
