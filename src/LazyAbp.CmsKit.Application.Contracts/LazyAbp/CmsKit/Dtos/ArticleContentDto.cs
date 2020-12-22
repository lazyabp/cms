using System;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.CmsKit.Dtos
{
    [Serializable]
    public class ArticleContentDto
    {
        public Guid ArticleId { get; set; }

        public string Key { get; set; }

        public string Content { get; set; }
    }
}