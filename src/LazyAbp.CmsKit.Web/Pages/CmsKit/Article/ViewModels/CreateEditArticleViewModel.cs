using System;

using System.ComponentModel.DataAnnotations;

namespace LazyAbp.CmsKit.Web.Pages.CmsKit.Article.ViewModels
{
    public class CreateEditArticleViewModel
    {
        [Display(Name = "ArticleTitle")]
        public string Title { get; set; }

        [Display(Name = "ArticleOrigin")]
        public string Origin { get; set; }

        [Display(Name = "ArticleAuth")]
        public string Auth { get; set; }

        [Display(Name = "ArticleThumbnail")]
        public string Thumbnail { get; set; }

        [Display(Name = "ArticleDescritpion")]
        public string Descritpion { get; set; }

        [Display(Name = "ArticleFile")]
        public string File { get; set; }

        [Display(Name = "ArticleVideo")]
        public string Video { get; set; }

        [Display(Name = "ArticlePrice")]
        public decimal? Price { get; set; }

        [Display(Name = "ArticleHits")]
        public int Hits { get; set; }

        [Display(Name = "ArticleLikes")]
        public int Likes { get; set; }

        [Display(Name = "ArticleDislikes")]
        public int Dislikes { get; set; }

        [Display(Name = "ArticleFavorites")]
        public int Favorites { get; set; }

        [Display(Name = "ArticleComments")]
        public int Comments { get; set; }

        [Display(Name = "ArticleSales")]
        public int Sales { get; set; }
    }
}