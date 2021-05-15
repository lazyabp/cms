using System;
using System.ComponentModel;

namespace Lazy.Abp.Cms.ArticleLikes.Dtos
{
    [Serializable]
    public class CreateUpdateArticleLikeDto
    {
        public Guid ArticleId { get; set; }

        public bool LikeOrDislike { get; set; }
    }
}