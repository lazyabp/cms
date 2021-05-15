using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Lazy.Abp.Cms
{
    public class ArticleContent : Entity
    {
        public virtual Guid ArticleId { get; set; }

        [MaxLength(ArticleConsts.MaxContentKeyLength)]
        public virtual string Key { get; protected set; }

        public virtual string Content { get; protected set; }

        public override object[] GetKeys()
        {
            return new object[] { ArticleId, };
        }

        private ArticleContent()
        {
        }

        internal ArticleContent(Guid articleId, string key, string content)
        {
            ArticleId = articleId;
            Key = key;
            Content = content;
        }

        internal void UpdateContent(string content)
        {
            Content = content;
        }
    }
}
