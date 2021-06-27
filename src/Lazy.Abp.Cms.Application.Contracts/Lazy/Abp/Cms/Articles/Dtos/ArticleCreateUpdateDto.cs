using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Lazy.Abp.Cms.Articles.Dtos
{
    [Serializable]
    public class ArticleCreateUpdateDto
    {
        public string Title { get; set; }

        public string Origin { get; set; }

        public string Auth { get; set; }

        public string Thumbnail { get; set; }

        public string Description { get; set; }

        public string File { get; set; }

        public string Video { get; set; }

        public decimal RetailPrice { get; set; }

        public decimal SalePrice { get; set; }

        public Guid? UserCategoryId { get; set; }

        public bool IsActive { get; set; }

        public AuditStatus? Status { get; set; }

        public string TemplateName { get; set; }

        public int HitCount { get; set; }

        public int LikeCount { get; set; }

        public int DislikeCount { get; set; }

        public int FavoriteCount { get; set; }

        public int SaleCount { get; set; }

        public DateTime? RealTime { get; set; }

        public ArticleMetaCreateUpdateDto Meta { get; set; }

        public ArticleContentCreateUpdateDto Content { get; set; }

        public List<string> Pictures { get; set; }

        public List<Guid> Categories { get; set; }

        public List<string> Tags { get; set; }
    }
}