using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace LazyAbp.CmsKit.Dtos
{
    [Serializable]
    public class CreateUpdateArticleContentDto
    {
        public List<string> Images { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }
    }
}