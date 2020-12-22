using System;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.CmsKit.Dtos
{
    [Serializable]
    public class ArticleTagDto : EntityDto
    {
        public Guid TagId { get; set; }

        public Guid ArticleId { get; set; }

        public TagDto Tag { get; set; }
    }
}