using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Cms.Dtos
{
    public class GetArticleListByTagRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? TagId { get; set; }

        public string Tag { get; set; }

        public bool IncludeDetails { get; set; }
    }
}
