using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Lazy.Abp.Cms.Articles
{
    public class ArticlePicture : Entity<Guid>
    {
        public Guid ArticleId { get; protected set; }

        public string PictureUrl { get; protected set; }

        private ArticlePicture()
        {
        }

        internal ArticlePicture(Guid id, Guid articleId, string pictureUrl) : base(id)
        {
            ArticleId = articleId;
            PictureUrl = pictureUrl;
        }
    }
}
