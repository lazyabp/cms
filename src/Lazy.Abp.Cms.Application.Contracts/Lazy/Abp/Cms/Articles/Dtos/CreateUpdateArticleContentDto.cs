using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Lazy.Abp.Cms.Articles.Dtos
{
    [Serializable]
    public class CreateUpdateArticleContentDto
    {
        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }
    }
}