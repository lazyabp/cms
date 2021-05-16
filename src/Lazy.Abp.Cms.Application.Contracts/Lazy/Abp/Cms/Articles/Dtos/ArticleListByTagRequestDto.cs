using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Cms.Articles.Dtos
{
    public class ArticleListByTagRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? TagId { get; set; }

        public string Tag { get; set; }
    }
}
