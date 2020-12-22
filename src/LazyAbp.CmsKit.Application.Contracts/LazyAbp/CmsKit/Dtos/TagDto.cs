using System;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.CmsKit.Dtos
{
    [Serializable]
    public class TagDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public int Hits { get; set; }
    }
}