using System;
using System.Collections.Generic;
using System.Text;

namespace Lazy.Abp.Cms.Articles.Dtos
{
    [Serializable]
    public class ArticleCategoryCreateUpdateDto
    {
        public Guid CategoryId { get; set; }
    }
}
