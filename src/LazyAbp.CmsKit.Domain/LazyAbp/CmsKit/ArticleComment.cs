using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace LazyAbp.CmsKit
{
    public class ArticleComment : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; }

        public Guid UserId { get; protected set; }

        /// <summary>
        /// 文章ID
        /// </summary>
        public Guid ArticleId { get; protected set; }

        /// <summary>
        /// 评论的上级ID
        /// </summary>
        public Guid? ParentId { get; protected set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        [NotNull]
        public string Content { get; protected set; }

        /// <summary>
        /// 评论人IP地址
        /// </summary>
        public string IpAddress { get; protected set; }

        /// <summary>
        /// 评论人浏览器信息
        /// </summary>
        public string UserAgent { get; protected set; }

        /// <summary>
        /// 评论状态
        /// </summary>
        public AuditStatus Status { get; protected set; }

        /// <summary>
        /// 审核备注
        /// </summary>
        public string AuditRemark { get; protected set; }

        public virtual Article Article { get; set; }

        protected ArticleComment()
        {
        }

        public ArticleComment(
            Guid id, 
            Guid userId, 
            Guid articleId, 
            Guid parentId, 
            string content, 
            string ipAddress, 
            string userAgent
        ) : base(id)
        {
            UserId = userId;
            ArticleId = articleId;
            ParentId = parentId;
            Content = content;
            IpAddress = ipAddress;
            UserAgent = userAgent;
        }

        public void Audit(AuditStatus status, string auditRemark)
        {
            Status = status;
            AuditRemark = auditRemark;
        }
    }
}
