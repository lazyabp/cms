using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.CmsKit.Dtos
{
    public class GetTagListRequestDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
