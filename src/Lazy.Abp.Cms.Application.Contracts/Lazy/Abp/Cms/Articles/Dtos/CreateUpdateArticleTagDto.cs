using System;
using System.ComponentModel;

namespace Lazy.Abp.Cms.Articles.Dtos
{
    [Serializable]
    public class CreateUpdateArticleTagDto
    {
        public string TagName { get; set; }
    }
}