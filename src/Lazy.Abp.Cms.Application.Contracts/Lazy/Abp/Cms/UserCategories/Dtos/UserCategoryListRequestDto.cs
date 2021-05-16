using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Cms.UserCategories.Dtos
{
    public class UserCategoryListRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? UserId { get; set; }

        public string Filter { get; set; }
    }
}
