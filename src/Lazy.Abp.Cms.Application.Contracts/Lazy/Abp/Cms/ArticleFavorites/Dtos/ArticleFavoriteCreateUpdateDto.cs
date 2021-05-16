using System;
using System.ComponentModel;

namespace Lazy.Abp.Cms.ArticleFavorites.Dtos
{
    [Serializable]
    public class ArticleFavoriteCreateUpdateDto
    {
        public Guid ArticleId { get; set; }
    }
}