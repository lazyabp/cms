using System;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.CmsKit.Dtos
{
    [Serializable]
    public class CategoryDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Label { get; set; }

        public int Depth { get; set; }

        public Guid? ParentId { get; set; }

        public Guid? RootId { get; set; }

        public string Path { get; set; }

        public string ListTemplateName { get; set; }

        public string DetailTemplateName { get; set; }

        public int DisplayOrder { get; set; }
    }
}