using System;
using System.ComponentModel;
namespace LazyAbp.CmsKit.Dtos
{
    [Serializable]
    public class CreateUpdateArticleLikeDto
    {
        public Guid UserId { get; set; }

        public Guid ArticleId { get; set; }

        public bool LikeOrDislike { get; set; }
    }
}