using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Cms.Articles.Dtos
{
    [Serializable]
    public class ArticleContentDto
    {
        public Guid ArticleId { get; set; }

        public string ShortDescritpion { get; set; }

        public string FullDescription { get; set; }
    }
}