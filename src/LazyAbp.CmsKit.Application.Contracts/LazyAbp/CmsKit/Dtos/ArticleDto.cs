using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.CmsKit.Dtos
{
    [Serializable]
    public class ArticleDto : FullAuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Origin { get; set; }

        public string Auth { get; set; }

        public string Thumbnail { get; set; }

        public string Descritpion { get; set; }

        public string File { get; set; }

        public string Video { get; set; }

        public bool IsFree { get; set; }

        public decimal? RetailPrice { get; set; }

        public decimal? SalePrice { get; set; }

        public Guid? UserCategoryId { get; set; }

        public string TemplateName { get; set; }

        public int HitCount { get; set; }

        public int LikeCount { get; set; }

        public int DislikeCount { get; set; }

        public int FavoriteCount { get; set; }

        public int CommentCount { get; set; }

        public int SaleCount { get; set; }

        public bool IsActive { get; set; }

        public AuditStatus Status { get; set; }

        public virtual List<ArticlePictureDto> Pictures { get; set; }

        public virtual List<ArticleContentDto> Contents { get; set; }

        public virtual List<ArticleCategoryDto> Categories { get; set; }

        public virtual List<ArticleTagDto> Tags { get; set; }
    }
}