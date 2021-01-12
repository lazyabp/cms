using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace LazyAbp.CmsKit
{
    public class Article : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; }

        public virtual Guid UserId { get; protected set; }

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

        //public virtual ArticleMeta Meta { get; set; }

        public virtual bool IsActive { get; protected set; }

        public virtual AuditStatus Status { get; protected set; }

        public virtual List<ArticlePicture> Pictures { get; set; }

        public virtual List<ArticleContent> Contents { get; set; }

        public virtual List<ArticleCategory> Categories { get; set; }

        public virtual List<ArticleTag> Tags { get; set; }

        protected Article()
        {
        }

        public Article(
            Guid id,
            Guid? tenantId,
            Guid userId,
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
            UserId = userId;
            Title = title;
            Origin = origin;
            Auth = auth;
            Thumbnail = thumbnail;
            Descritpion = descritpion;
            File = file;
            Video = video;
            IsFree = true;

            //Meta = new ArticleMeta(id);
            Pictures = new List<ArticlePicture>();
            Contents = new List<ArticleContent>();
            Categories = new List<ArticleCategory>();
            Tags = new List<ArticleTag>();
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

        public void AddPicture(string pictureUrl)
        {
            if (!Pictures.Any(x => x.PictureUrl == pictureUrl))
                Pictures.Add(new ArticlePicture(Id, pictureUrl));
        }

        public void AddContent(string key, string content)
        {
            var item = Contents.FirstOrDefault(x => x.Key == key);

            if (item == null)
                Contents.Add(new ArticleContent(Id, key, content));
            else
                item.UpdateContent(content);
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
    }
}
