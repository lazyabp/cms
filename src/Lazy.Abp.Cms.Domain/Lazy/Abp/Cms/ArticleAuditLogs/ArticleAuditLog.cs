using Lazy.Abp.Cms.Articles;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lazy.Abp.Cms.ArticleAuditLogs
{
    public class ArticleAuditLog : CreationAuditedAggregateRoot<Guid>
    {
        public Guid? TenantId { get; protected set; }

        public Guid ArticleId { get; protected set; }

        public virtual AuditStatus Status { get; protected set; }

        public virtual string Remark { get; protected set; }

        protected ArticleAuditLog()
        {
        }

        public ArticleAuditLog(Guid id, Guid? tenantId, Guid articleId, AuditStatus status, string remark)
            : base(id)
        {
            TenantId = tenantId;
            ArticleId = articleId;
            Status = status;
            Remark = remark;
        }
    }
}
