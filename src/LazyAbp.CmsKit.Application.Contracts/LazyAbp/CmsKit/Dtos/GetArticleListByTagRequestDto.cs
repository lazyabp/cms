using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.CmsKit.Dtos
{
    public class GetArticleListByTagRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? TagId { get; set; }

        public string Tag { get; set; }

        public bool IncludeDetails { get; set; }
    }
}
