using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Cms.Dtos
{
    public class ArticlePictureDto : EntityDto<Guid>
    {
        public Guid ArticleId { get; set; }

        public string PictureUrl { get; set; }
    }
}
