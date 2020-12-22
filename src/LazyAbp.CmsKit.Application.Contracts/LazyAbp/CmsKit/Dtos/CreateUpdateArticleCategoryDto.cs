using System;
using System.Collections.Generic;
using System.Text;

namespace LazyAbp.CmsKit.Dtos
{
    [Serializable]
    public class CreateUpdateArticleCategoryDto
    {
        public Guid CategoryId { get; set; }

        public Guid ArticleId { get; set; }
    }
}
