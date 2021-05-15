using System;
using System.Collections.Generic;
using System.Text;

namespace Lazy.Abp.Cms.ArticleAuditLogs.Dtos
{
    public class AuditRequestDto
    {
        public AuditStatus Status { get; set; }

        public string Remark { get; set; }
    }
}
