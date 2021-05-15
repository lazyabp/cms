using Lazy.Abp.Cms.Articles.Dtos;
using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Cms.ArticleComments.Dtos
{
    [Serializable]
    public class ArticleCommentDto : FullAuditedEntityDto<Guid>
    {
        public Guid ArticleId { get; set; }

        public Guid? ParentId { get; set; }

        public string Content { get; set; }

        public string IpAddress { get; set; }

        public string UserAgent { get; set; }

        public AuditStatus Status { get; set; }

        public string AuditRemark { get; set; }

        public virtual ArticleDto Article { get; set; }
    }
}