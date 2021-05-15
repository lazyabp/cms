using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace Lazy.Abp.Cms.Dtos
{
    [Serializable]
    public class CreateUpdateArticleContentDto
    {
        public List<string> Images { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }
    }
}