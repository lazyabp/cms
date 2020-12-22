﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.CmsKit.Dtos
{
    public class GetArticleListRequestDto : PagedAndSortedResultRequestDto
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

        public bool IncludeDetails { get; set; }
    }
}