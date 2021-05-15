using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Cms.Articles.Dtos
{
    public class ArticlePictureDto : EntityDto<Guid>
    {
        public Guid ArticleId { get; set; }

        public string PictureUrl { get; set; }
    }
}
