using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.CmsKit.Dtos
{
    public class ArticleAuditLogDto : CreationAuditedEntityDto<Guid>
    {
        public Guid ArticleId { get; set; }

        public virtual AuditStatus Status { get; set; }

        public virtual string Remark { get; set; }
    }
}
