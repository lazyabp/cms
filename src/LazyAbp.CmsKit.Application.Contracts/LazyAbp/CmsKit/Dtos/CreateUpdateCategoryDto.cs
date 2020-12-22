using System;
using System.ComponentModel;
namespace LazyAbp.CmsKit.Dtos
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