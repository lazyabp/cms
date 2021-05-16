using System;
using System.ComponentModel;

namespace Lazy.Abp.Cms.Articles.Dtos
{
    [Serializable]
    public class ArticleMetaCreateUpdateDto
    {
        public string MetaTitle { get; set; }

        public string Keywords { get; set; }

        public string MetaDescription { get; set; }
    }
}