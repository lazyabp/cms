using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace LazyAbp.CmsKit
{
    public class ArticleCategory : Entity
    {
        public virtual Guid CategoryId { get; protected set; }

        public virtual Guid ArticleId { get; protected set; }

        public override object[] GetKeys()
        {
            return new object[] { CategoryId, ArticleId };
        }

        private ArticleCategory()
        {
        }

        internal ArticleCategory(
            Guid categoryId, 
            Guid articleId
        )
        {
            CategoryId = categoryId;
            ArticleId = articleId;
        }
    }
}
