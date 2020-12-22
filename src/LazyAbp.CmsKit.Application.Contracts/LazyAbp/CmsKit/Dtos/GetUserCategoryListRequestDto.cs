using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.CmsKit.Dtos
{
    public class GetUserCategoryListRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? UserId { get; set; }

        public string Filter { get; set; }
    }
}
