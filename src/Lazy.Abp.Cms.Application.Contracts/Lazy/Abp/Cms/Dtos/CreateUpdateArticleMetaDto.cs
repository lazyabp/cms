using System;
using System.ComponentModel;
namespace Lazy.Abp.Cms.Dtos
{
    [Serializable]
    public class CreateUpdateArticleMetaDto
    {
        public string MetaTitle { get; set; }

        public string Keywords { get; set; }

        public string MetaContent { get; set; }
    }
}