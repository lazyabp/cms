using System;
using System.ComponentModel;
namespace Lazy.Abp.Cms.Dtos
{
    [Serializable]
    public class CreateUpdateArticleTagDto
    {
        public Guid TagId { get; set; }

        public Guid ArticleId { get; set; }
    }
}