using JetBrains.Annotations;
using Lazy.Abp.Cms.ArticleAuditLogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lazy.Abp.Cms.Articles
{
    public class Article : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; }

        [NotNull]
        [MaxLength(ArticleConsts.MaxTitleLength)]
        public virtual string Title { get; protected set; }

        [MaxLength(ArticleConsts.MaxOriginLength)]
        public virtual string Origin { get; protected set; }

        [MaxLength(ArticleConsts.MaxAuthLength)]
        public virtual string Auth { get; protected set; }

        [MaxLength(ArticleConsts.MaxThumbnailLength)]
        public virtual string Thumbnail { get; protected set; }

        [MaxLength(ArticleConsts.MaxDescritpionLength)]
        public virtual string Descritpion { get; protected set; }

        [MaxLength(ArticleConsts.MaxFileLength)]
        public virtual string File { get; protected set; }

        [MaxLength(ArticleConsts.MaxVideoLength)]
        public virtual string Video { get; protected set; }

        public virtual bool IsFree { get; protected set; }

        public virtual decimal? RetailPrice { get; protected set; }

        public virtual decimal? SalePrice { get; protected set; }

        public virtual Guid? UserCategoryId { get; protected set; }

        public virtual string TemplateName { get; protected set; }

        /// <summary>
        /// 点击量
        /// </summary>
        public virtual int HitCount { get; protected set; }

        /// <summary>
        /// 喜欢量
        /// </summary>
        public virtual int LikeCount { get; protected set; }

        /// <summary>
        /// 不喜欢量
        /// </summary>
        public virtual int DislikeCount { get; protected set; }

        /// <summary>
        /// 收藏量
        /// </summary>
        public virtual int FavoriteCount { get; protected set; }

        /// <summary>
        /// 评论量
        /// </summary>
        public virtual int CommentCount { get; protected set; }

        /// <summary>
        /// 销售量
        /// </summary>
        public virtual int SaleCount { get; protected set; }

        public virtual bool IsActive { get; protected set; }

        public virtual AuditStatus Status { get; protected set; }

        public virtual ArticleMeta Meta { get; set; }

        public virtual ICollection<ArticlePicture> Pictures { get; set; }

        public virtual ArticleContent Content { get; set; }

        public virtual ICollection<ArticleCategory> Categories { get; set; }

        public virtual ICollection<ArticleTag> Tags { get; set; }

        public virtual ICollection<ArticleAuditLog> Logs { get; set; }

        protected Article()
        {
        }

        public Article(
            Guid id,
            Guid? tenantId,
            string title,
            string origin,
            string auth,
            string thumbnail,
            string descritpion,
            string file,
            string video
        ) : base(id)
        {
            TenantId = tenantId;
            Title = title;
            Origin = origin;
            Auth = auth;
            Thumbnail = thumbnail;
            Descritpion = descritpion;
            File = file;
            Video = video;
            IsFree = true;

            Pictures = new Collection<ArticlePicture>();
            Categories = new Collection<ArticleCategory>();
            Tags = new Collection<ArticleTag>();
            Logs = new Collection<ArticleAuditLog>();
        }

        public void Update(
            string title,
            string origin,
            string auth,
            string thumbnail,
            string descritpion,
            string file,
            string video
        )
        {
            Title = title;
            Origin = origin;
            Auth = auth;
            Thumbnail = thumbnail;
            Descritpion = descritpion;
            File = file;
            Video = video;
        }

        public void SetCreationTime(DateTime dateTime)
        {
            CreationTime = dateTime;
        }

        /// <summary>
        /// 点击量
        /// </summary>
        public void SetHits(int hits)
        {
            HitCount = hits;
        }

        /// <summary>
        /// 喜欢量
        /// </summary>
        public void SetLikes(int likes)
        {
            LikeCount = likes;
        }

        /// <summary>
        /// 不喜欢量
        /// </summary>
        public void SetDislikes(int dislikes)
        {
            DislikeCount = dislikes;
        }

        /// <summary>
        /// 收藏量
        /// </summary>
        public void SetFavorites(int favorites)
        {
            FavoriteCount = favorites;
        }

        /// <summary>
        /// 评论量
        /// </summary>
        public void SetComments(int comments)
        {
            CommentCount = comments;
        }

        /// <summary>
        /// 销售量
        /// </summary>
        public void SetSales(int sales)
        {
            SaleCount = sales;
        }

        /// <summary>
        /// 设置价格
        /// </summary>
        /// <param name="retailPrice"></param>
        /// <param name="salePrice"></param>
        public void SetPrice(decimal retailPrice, decimal salePrice)
        {
            if (salePrice < 0 || salePrice < 0)
                throw new Exception("InvalidPrice");

            if (salePrice == 0)
                salePrice = retailPrice;

            RetailPrice = retailPrice;
            SalePrice = salePrice;

            IsFree = salePrice == 0;
        }

        public void AddPicture(Guid pictureId, string pictureUrl)
        {
            if (!Pictures.Any(x => x.PictureUrl == pictureUrl))
                Pictures.Add(new ArticlePicture(pictureId, Id, pictureUrl));
        }

        public void SetContent(string shortDescritpion, string fullDescription)
        {
            if (null != Content)
                Content = new ArticleContent(Id, shortDescritpion, fullDescription);
            else
                Content.Update(shortDescritpion, fullDescription);
        }

        public void AddCategory(Guid categoryId)
        {
            if (!Categories.Any(x => x.CategoryId == categoryId))
                Categories.Add(new ArticleCategory(categoryId, Id));
        }

        public void AddTag(Guid tagId)
        {
            if (!Tags.Any(x => x.TagId == tagId))
                Tags.Add(new ArticleTag(tagId, Id));
        }

        public void SetUserCategory(Guid userCategoryId)
        {
            UserCategoryId = userCategoryId;
        }

        public void SetTemplateName(string templateName)
        {
            TemplateName = templateName;
        }

        public void SetActive(bool isActive)
        {
            IsActive = isActive;
        }

        public void SetAuditStatus(AuditStatus status)
        {
            Status = status;
        }

        public void SetMeta(
            string metaTitle,
            string keywords,
            string metaDescription
        )
        {
            if (null == Meta)
            {
                Meta = new ArticleMeta(Id, metaTitle, keywords, metaDescription);
            }
            else
            {
                Meta.Update(metaTitle, keywords, metaDescription);
            }
        }
    }
}
