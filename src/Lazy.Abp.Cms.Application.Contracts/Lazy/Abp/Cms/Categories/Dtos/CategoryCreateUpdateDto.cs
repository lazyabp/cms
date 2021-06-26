using System;
using System.ComponentModel;

namespace Lazy.Abp.Cms.Categories.Dtos
{
    [Serializable]
    public class CategoryCreateUpdateDto
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public Guid? ParentId { get; set; }

        public string ListTemplateName { get; set; }

        public string DetailTemplateName { get; set; }

        public int DisplayOrder { get; set; }
    }
}