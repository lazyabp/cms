using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Cms.Categories.Dtos
{
    [Serializable]
    public class CategoryViewDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public int Depth { get; set; }

        public Guid? ParentId { get; set; }

        public Guid? RootId { get; set; }

        public string Path { get; set; }

        public string ListTemplateName { get; set; }

        public string DetailTemplateName { get; set; }

        public int DisplayOrder { get; set; }
    }
}