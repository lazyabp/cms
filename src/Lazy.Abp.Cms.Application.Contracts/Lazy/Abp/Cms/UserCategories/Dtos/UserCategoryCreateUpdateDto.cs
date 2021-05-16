using System;

namespace Lazy.Abp.Cms.UserCategories.Dtos
{
    [Serializable]
    public class UserCategoryCreateUpdateDto
    {
        public string Name { get; set; }

        public int DisplayOrder { get; set; }
    }
}