using Lazy.Abp.Cms.ArticleAuditLogs;
using Lazy.Abp.Cms.ArticleAuditLogs.Dtos;
using Lazy.Abp.Cms.Articles.Dtos;
using Lazy.Abp.Cms.Categories;
using Lazy.Abp.Cms.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.Cms.Articles
{
    public class ArticleCommonAppService : CmsAppService, IArticleCommonAppService, ITransientDependency
    {
        private readonly IArticleRepository _repository;
        private readonly ITagRepository _tagRepository;
        private readonly IArticleAuditLogManager _logManager;

        public ArticleCommonAppService(IArticleRepository repository,
            ITagRepository tagRepository,
            ICategoryRepository categoryRepository,
            IArticleAuditLogManager logManager)
        {
            _repository = repository;
            _tagRepository = tagRepository;
            _logManager = logManager;
        }

        public async Task<ArticleDto> GetAsync(Guid id)
        {
            var article = await _repository.GetAsync(id);
            var result = ObjectMapper.Map<Article, ArticleDto>(article);

            return result;
        }

        public async Task<PagedResultDto<ArticleDto>> GetListAsync(ArticleListRequestDto input)
        {
            var totalCount = await _repository.GetCountAsync(input.UserId, input.HasFile, input.HasVideo, input.IsFree, input.IsActive, input.Status,
                input.UserCategoryId, input.CreatedAfter, input.CreatedBefore, input.Filter);

            var list = await _repository.GetListAsync(input.UserId, input.HasFile, input.HasVideo, input.IsFree, input.IsActive, input.Status, 
                input.UserCategoryId, input.CreatedAfter, input.CreatedBefore, input.Filter, input.MaxResultCount, input.SkipCount, input.Sorting);

            var items = ObjectMapper.Map<List<Article>, List<ArticleDto>>(list);

            return new PagedResultDto<ArticleDto>(
                totalCount,
                items
            );
        }

        public async Task<PagedResultDto<ArticleDto>> GetListByTagAsync(ArticleListByTagRequestDto input)
        {
            if (!input.TagId.HasValue && input.Tag.IsNullOrEmpty())
                throw new UserFriendlyException(L["MissingParameters"]);

            if (!input.Tag.IsNullOrEmpty())
            {
                var tag = await _tagRepository.GetByNameAsync(input.Tag);
                if (tag == null)
                    return new PagedResultDto<ArticleDto>();

                input.TagId = tag.Id;
            }

            var totalCount = await _repository.GetCountByTagAsync(input.TagId.Value);
            var list = await _repository.GetListByTagAsync(input.TagId.Value, true, AuditStatus.Passed, input.MaxResultCount, input.SkipCount, input.Sorting);

            var items = ObjectMapper.Map<List<Article>, List<ArticleDto>>(list);

            return new PagedResultDto<ArticleDto>(
                totalCount,
                items
            );
        }

        public async Task<ArticleDto> CreateAsync(ArticleCreateUpdateDto input)
        {
            var article = new Article(GuidGenerator.Create(), CurrentTenant.Id, input.Title, 
                input.Origin, input.Auth, input.Thumbnail, input.Descritpion, input.File, input.Video);

            article.SetHits(input.HitCount);
            article.SetLikes(input.LikeCount);
            article.SetDislikes(input.DislikeCount);
            article.SetFavorites(input.FavoriteCount);
            article.SetSales(input.SaleCount);
            article.SetPrice(input.RetailPrice, input.SalePrice);
            article.SetTemplateName(input.TemplateName);
            article.SetActive(input.IsActive);

            if (input.CreationTime.HasValue)
                article.SetCreationTime(input.CreationTime.Value);

            if (input.UserCategoryId.HasValue)
                article.SetUserCategory(input.UserCategoryId.Value);

            article.SetMeta(input.Meta?.MetaTitle, input.Meta?.Keywords, input.Meta?.MetaDescription);
            article.SetContent(input.Content?.ShortDescription, input.Content?.FullDescription);

            // 图片
            if (input.Pictures?.Count > 0)
            {
                foreach (var pictureUrl in input.Pictures)
                    article.AddPicture(GuidGenerator.Create(), pictureUrl);
            }

            // 绑定目录
            if (input.Categories?.Count > 0)
            {
                foreach (var categoryId in input.Categories)
                    article.AddCategory(categoryId);
            }

            // Tag
            if (input.Tags?.Count > 0)
            {
                var tags = await _tagRepository.GetAndCreateTagsAsync(input.Tags);
                foreach (var tag in tags)
                    article.AddTag(tag.Id);
            }

            article = await _repository.InsertAsync(article);

            return ObjectMapper.Map<Article, ArticleDto>(article);
        }

        public async Task<ArticleDto> UpdateAsync(Guid id, ArticleCreateUpdateDto input)
        {
            var article = await _repository.GetByIdAsync(id, true);

            article.Update(input.Title, input.Origin, input.Auth, input.Thumbnail, input.Descritpion, input.File, input.Video);
            article.SetHits(input.HitCount);
            article.SetLikes(input.LikeCount);
            article.SetDislikes(input.DislikeCount);
            article.SetFavorites(input.FavoriteCount);
            article.SetSales(input.SaleCount);
            article.SetPrice(input.RetailPrice, input.SalePrice);
            article.SetActive(input.IsActive);

            article.SetTemplateName(input.TemplateName);

            if (input.CreationTime.HasValue)
                article.SetCreationTime(input.CreationTime.Value);

            if (input.UserCategoryId.HasValue)
                article.SetUserCategory(input.UserCategoryId.Value);

            article.SetMeta(input.Meta?.MetaTitle, input.Meta?.Keywords, input.Meta?.MetaDescription);
            article.SetContent(input.Content?.ShortDescription, input.Content?.FullDescription);

            // 图片
            if (input.Pictures?.Count == 0)
            {
                article.Pictures.Clear();
            }
            else
            {
                article.Pictures.RemoveAll(x => !input.Pictures.Contains(x.PictureUrl));

                foreach (var pictureUrl in input.Pictures)
                    article.AddPicture(GuidGenerator.Create(), pictureUrl);
            }

            // 绑定目录
            if (input.Categories?.Count == 0)
            {
                article.Categories.Clear();
            }
            else
            {
                article.Categories.RemoveAll(x => !input.Categories.Contains(x.CategoryId));

                foreach (var categoryId in input.Categories)
                    article.AddCategory(categoryId);
            }

            // Tag
            if (input.Tags?.Count == 0)
            {
                article.Tags.Clear();
            }
            else
            {
                var tags = await _tagRepository.GetAndCreateTagsAsync(input.Tags);
                var tagIds = tags.Select(x => x.Id).ToList();

                article.Tags.RemoveAll(x => !tagIds.Contains(x.TagId));

                foreach (var tag in tags)
                    article.AddTag(tag.Id);
            }

            article = await _repository.UpdateAsync(article);

            return ObjectMapper.Map<Article, ArticleDto>(article);
        }

        public async Task SetActiveAsync(Guid id, SetActiveRequestDto input)
        {
            var article = await _repository.GetAsync(id);
            article.SetActive(input.IsActive);

            await _repository.UpdateAsync(article);
        }

        public async Task<ArticleAuditLogDto> AuditAsync(Guid id, AuditRequestDto input)
        {
            var article = await _repository.GetAsync(id);
            article.SetAuditStatus(input.Status);

            var result = await _logManager.WriteAsync(article.Id, article.TenantId, input.Status, input.Remark);

            return ObjectMapper.Map<ArticleAuditLog, ArticleAuditLogDto>(result);
        }
    }
}
