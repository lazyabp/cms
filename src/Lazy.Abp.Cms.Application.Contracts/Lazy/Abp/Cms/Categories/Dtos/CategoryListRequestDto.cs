using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Cms.Categories.Dtos
{
    public class CategoryListRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? ParentId { get; set; }

        public Guid? RootId { get; set; }

        public string Filter { get; set; }
    }
}
