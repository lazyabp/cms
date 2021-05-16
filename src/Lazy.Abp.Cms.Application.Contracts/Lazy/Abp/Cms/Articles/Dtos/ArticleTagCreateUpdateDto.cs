using System;
using System.ComponentModel;

namespace Lazy.Abp.Cms.Articles.Dtos
{
    [Serializable]
    public class ArticleTagCreateUpdateDto
    {
        public string TagName { get; set; }
    }
}