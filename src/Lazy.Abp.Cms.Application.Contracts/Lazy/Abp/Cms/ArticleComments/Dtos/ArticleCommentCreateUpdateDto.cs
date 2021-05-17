using System;
using System.ComponentModel;
namespace Lazy.Abp.Cms.ArticleComments.Dtos
{
    [Serializable]
    public class ArticleCommentCreateUpdateDto
    {
        //public Guid UserId { get; set; }

        public Guid ArticleId { get; set; }

        public Guid? ParentId { get; set; }

        public string Content { get; set; }

        //public string IpAddress { get; set; }

        //public string UserAgent { get; set; }
    }
}