using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace LazyAbp.CmsKit
{
    public class ArticlePicture : Entity<Guid>
    {
        public Guid ArticleId { get; protected set; }

        public string PictureUrl { get; protected set; }

        private ArticlePicture()
        {
        }

        internal ArticlePicture(Guid articleId, string pictureUrl)
        {
            Id = Guid.NewGuid();
            ArticleId = articleId;
            PictureUrl = pictureUrl;
        }
    }
}
