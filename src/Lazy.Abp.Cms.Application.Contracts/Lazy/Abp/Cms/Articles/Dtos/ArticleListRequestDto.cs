using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Cms.Articles.Dtos
{
    public class ArticleListRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? UserId { get; set; }

        public bool? HasFile { get; set; }

        public bool? HasVideo { get; set; }

        public bool? IsFree { get; set; }

        public bool? IsActive { get; set; }

        public AuditStatus? Status { get; set; }

        public Guid? UserCategoryId { get; set; }

        public DateTime? CreatedAfter { get; set; }

        public DateTime? CreatedBefore { get; set; }

        public string Filter { get; set; }
    }
}
