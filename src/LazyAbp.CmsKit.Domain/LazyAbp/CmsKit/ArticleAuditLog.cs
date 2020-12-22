using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace LazyAbp.CmsKit
{
    public class ArticleAuditLog : CreationAuditedAggregateRoot<Guid>
    {
        public Guid ArticleId { get; protected set; }

        public virtual AuditStatus Status { get; protected set; }

        public virtual string Remark { get; protected set; }

        public virtual Article Article { get; set; }

        protected ArticleAuditLog()
        {
        }

        public ArticleAuditLog(Guid id, Guid articleId, AuditStatus status, string remark)
            : base(id)
        {
            ArticleId = articleId;
            Status = status;
            Remark = remark;
        }
    }
}
