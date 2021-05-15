using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Lazy.Abp.Cms.Articles
{
    public class ArticleMeta : Entity
    {
        public virtual Guid ArticleId { get; set; }

        [MaxLength(ArticleConsts.MaxMetaTitleLength)]
        public virtual string MetaTitle { get; protected set; }

        [MaxLength(ArticleConsts.MaxKeywordsLength)]
        public virtual string Keywords { get; protected set; }

        [MaxLength(ArticleConsts.MaxMetaContentLength)]
        public virtual string MetaDescription { get; protected set; }

        public override object[] GetKeys()
        {
            return new object[] { ArticleId };
        }

        private ArticleMeta()
        {
        }

        internal ArticleMeta(
            Guid articleId,
            string metaTitle,
            string keywords,
            string metaDescription
        )
        {
            ArticleId = articleId;
            MetaTitle = metaTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
        }

        internal void Update(
            string metaTitle, 
            string keywords, 
            string metaDescription
        )
        {
            MetaTitle = metaTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
        }
    }
}
