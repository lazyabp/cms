using System;
using System.ComponentModel;
namespace LazyAbp.CmsKit.Dtos
{
    [Serializable]
    public class CreateUpdateArticleFavoriteDto
    {
        public Guid UserId { get; set; }

        public Guid ArticleId { get; set; }
    }
}