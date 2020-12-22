using System;
using System.ComponentModel;
namespace LazyAbp.CmsKit.Dtos
{
    [Serializable]
    public class CreateUpdateArticleTagDto
    {
        public Guid TagId { get; set; }

        public Guid ArticleId { get; set; }
    }
}