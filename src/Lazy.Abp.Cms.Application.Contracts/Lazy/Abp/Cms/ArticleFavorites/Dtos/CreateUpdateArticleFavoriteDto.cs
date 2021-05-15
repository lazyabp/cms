using System;
using System.ComponentModel;

namespace Lazy.Abp.Cms.ArticleFavorites.Dtos
{
    [Serializable]
    public class CreateUpdateArticleFavoriteDto
    {
        public Guid ArticleId { get; set; }
    }
}