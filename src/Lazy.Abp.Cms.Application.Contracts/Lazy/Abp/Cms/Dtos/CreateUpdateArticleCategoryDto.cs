using System;
using System.Collections.Generic;
using System.Text;

namespace Lazy.Abp.Cms.Dtos
{
    [Serializable]
    public class CreateUpdateArticleCategoryDto
    {
        public Guid CategoryId { get; set; }

        public Guid ArticleId { get; set; }
    }
}
