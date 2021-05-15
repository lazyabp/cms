using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Cms.ArticleFavorites.Dtos
{
    public class GetArticleFavoriteListRequestDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public bool IncludeDetails { get; set; }
    }
}
