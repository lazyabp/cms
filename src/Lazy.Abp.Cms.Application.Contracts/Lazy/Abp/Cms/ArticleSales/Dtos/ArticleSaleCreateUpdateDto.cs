using System;
using System.ComponentModel;

namespace Lazy.Abp.Cms.ArticleSales.Dtos
{
    [Serializable]
    public class ArticleSaleCreateUpdateDto
    {
        public Guid UserId { get; set; }

        public Guid ArticleId { get; set; }
    }
}