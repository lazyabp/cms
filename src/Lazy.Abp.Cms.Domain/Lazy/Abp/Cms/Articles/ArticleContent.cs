using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Lazy.Abp.Cms.Articles
{
    public class ArticleContent : Entity
    {
        public virtual Guid ArticleId { get; set; }

        public virtual string ShortDescritpion { get; protected set; }

        public virtual string FullDescription { get; protected set; }

        public override object[] GetKeys()
        {
            return new object[] { ArticleId };
        }

        private ArticleContent()
        {
        }

        internal ArticleContent(Guid articleId, string shortDescritpion, string fullDescription)
        {
            ArticleId = articleId;
            ShortDescritpion = shortDescritpion;
            FullDescription = fullDescription;
        }

        internal void Update(string shortDescritpion, string fullDescription)
        {
            ShortDescritpion = shortDescritpion;
            FullDescription = fullDescription;
        }
    }
}
