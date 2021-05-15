using System;
using Volo.Abp.Domain.Entities;

namespace Lazy.Abp.Cms
{
    public class ArticleTag : Entity
    {
        public virtual Guid TagId { get; protected set; }

        public virtual Guid ArticleId { get; protected set; }

        public virtual Tag Tag { get; set; }

        public override object[] GetKeys()
        {
            return new object[] { TagId, ArticleId };
        }

        private ArticleTag()
        {
        }

        internal ArticleTag(
            Guid tagId, 
            Guid articleId
        )
        {
            TagId = tagId;
            ArticleId = articleId;
        }
    }
}
