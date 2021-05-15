using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Cms.SinglePages.Dtos
{
    public class GetSinglePageListRequestDto : PagedAndSortedResultRequestDto
    {
        public DateTime? CreatedAfter { get; set; }

        public DateTime? CreatedBefore { get; set; }

        public string Filter { get; set; }
    }
}
