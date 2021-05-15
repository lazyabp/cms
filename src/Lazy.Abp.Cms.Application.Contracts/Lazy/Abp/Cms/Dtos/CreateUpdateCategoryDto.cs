using System;
using System.ComponentModel;
namespace Lazy.Abp.Cms.Dtos
{
    [Serializable]
    public class CreateUpdateCategoryDto
    {
        public string Name { get; set; }

        public string Label { get; set; }

        public Guid? ParentId { get; set; }

        public int DisplayOrder { get; set; }
    }
}