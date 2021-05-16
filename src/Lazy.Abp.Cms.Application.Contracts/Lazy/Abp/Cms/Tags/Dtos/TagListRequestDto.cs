using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Cms.Tags.Dtos
{
    public class TagListRequestDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
