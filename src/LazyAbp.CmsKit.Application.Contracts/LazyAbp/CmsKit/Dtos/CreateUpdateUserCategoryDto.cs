using System;

namespace LazyAbp.CmsKit.Dtos
{
    [Serializable]
    public class CreateUpdateUserCategoryDto
    {
        public string Name { get; set; }

        public int DisplayOrder { get; set; }
    }
}