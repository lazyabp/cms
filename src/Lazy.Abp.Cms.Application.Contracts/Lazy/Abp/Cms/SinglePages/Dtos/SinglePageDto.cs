using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Cms.SinglePages.Dtos
{
    [Serializable]
    public class SinglePageDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Thumbnail { get; set; }

        public string FullDescription { get; set; }
    }
}