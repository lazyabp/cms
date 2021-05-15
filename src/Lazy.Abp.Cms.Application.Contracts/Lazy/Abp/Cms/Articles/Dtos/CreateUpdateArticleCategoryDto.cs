using System;
using System.Collections.Generic;
using System.Text;

namespace Lazy.Abp.Cms.Articles.Dtos
{
    [Serializable]
    public class CreateUpdateArticleCategoryDto
    {
        public Guid CategoryId { get; set; }
    }
}
