using System;

namespace Lazy.Abp.Cms.Dtos
{
    [Serializable]
    public class CreateUpdateUserCategoryDto
    {
        public string Name { get; set; }

        public int DisplayOrder { get; set; }
    }
}