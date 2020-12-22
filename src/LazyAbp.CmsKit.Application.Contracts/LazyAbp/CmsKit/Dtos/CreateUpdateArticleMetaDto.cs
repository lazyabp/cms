using System;
using System.ComponentModel;
namespace LazyAbp.CmsKit.Dtos
{
    [Serializable]
    public class CreateUpdateArticleMetaDto
    {
        public string MetaTitle { get; set; }

        public string Keywords { get; set; }

        public string MetaContent { get; set; }
    }
}