using System;
using System.Collections.Generic;
using System.Text;

namespace LazyAbp.CmsKit.Dtos
{
    public class AuditRequestDto
    {
        public AuditStatus Status { get; set; }

        public string Remark { get; set; }
    }
}
