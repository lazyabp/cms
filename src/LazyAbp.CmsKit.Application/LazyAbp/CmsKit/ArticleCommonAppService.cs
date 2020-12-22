using LazyAbp.CmsKit.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Users;

namespace LazyAbp.CmsKit
{
    public class ArticleCommonAppService : CmsKitAppService, IArticleCommonAppService, ITransientDependency
    {
        private readonly IArticleRepository _repository;
        private readonly ITagRepository _tagRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IArticleAuditLogManager _logManager;

        public ArticleCommonAppService(IArticleRepository repository,
            ITagRepository tagRepository,
            ICategoryRepository categoryRepository,
            IArticleAuditLogManager logManager)
        {
            _repository = repository;
            _tagRepository = tagRepository;
            _categoryRepository = categoryRepository;
            _logManager = logManager;
        }

        public async Task<ArticleViewDto> GetAsync(Guid id)
        {
            var article = await _repository.GetByIdAsync(id, true);
            var result = ObjectMapper.Map<Article, ArticleViewDto>(article);

            var categoryIds = article.Categories.Select(x => x.CategoryId).ToList();
            var tagIds = article.Tags.Select(x => x.TagId).ToList();
            // 找出分类和tag的详细
            //var categories = await _categoryRepository.GetByIdsAsync(categoryIds);
            var tags = await _tagRepository.GetByIdsAsync(tagIds);
            // 补全复合类型内容
            // 分类
            //foreach (var cat in article.Categories)
            //{
            //    var category = categories.FirstOrDefault(x => x.Id == cat.CategoryId);
            //    if (category != null)
            //        result.Categories.Add(ObjectMapper.Map<Category, CategoryViewDto>(category));
            //}
            result.Categories = categoryIds;
            // Tags
            foreach (var t in article.Tags)
            {
                var tag = tags.FirstOrDefault(x => x.Id == t.TagId);
                if (tag != null)
                    result.Tags.Add(tag.Name);
                    //result.Tags.Add(ObjectMapper.Map<Tag, TagDto>(tag));
            }
            // 详细
            foreach (var t in article.Contents)
            {
                result.Contents.Add(t.Key, t.Content);
            }
            // 图片
            foreach (var t in article.Pictures)
            {
                result.Pictures.Add(t.PictureUrl);
            }

            return result;
        }

        public async Task<PagedResultDto<ArticleViewDto>> GetListAsync(GetArticleListRequestDto input)
        {
            var totalCount = await _repository.GetCountAsync(input.UserId, input.HasFile, input.HasVideo, input.IsFree, input.IsActive, input.Status,
                input.UserCategoryId, input.CreatedAfter, input.CreatedBefore, input.Filter, input.IncludeDetails);

            var list = await _repository.GetListAsync(input.UserId, input.HasFile, input.HasVideo, input.IsFree, input.IsActive, input.Status, 
                input.UserCategoryId, input.CreatedAfter, input.CreatedBefore, input.Filter, input.IncludeDetails, input.MaxResultCount, input.SkipCount, input.Sorting);

            var items = await MapArticleViewDto(list, input.IncludeDetails);

            return new PagedResultDto<ArticleViewDto>(
                totalCount,
                items
            );
        }

        public async Task<PagedResultDto<ArticleViewDto>> GetListByTagAsync(GetArticleListByTagRequestDto input)
        {
            if (!input.TagId.HasValue && input.Tag.IsNullOrEmpty())
                throw new UserFriendlyException(L["MissingParameters"]);

            if (!input.Tag.IsNullOrEmpty())
            {
                var tag = await _tagRepository.GetByNameAsync(input.Tag);
                if (tag == null)
                    return new PagedResultDto<ArticleViewDto>();

                input.TagId = tag.Id;
            }

            var totalCount = await _repository.GetCountByTagAsync(input.TagId.Value);
            var list = await _repository.GetListByTagAsync(input.TagId.Value, true, AuditStatus.Passed, input.MaxResultCount, input.SkipCount, input.Sorting);

            var items = await MapArticleViewDto(list, input.IncludeDetails);

            return new PagedResultDto<ArticleViewDto>(
                totalCount,
                items
            );
        }

        public async Task<ArticleDto> CreateAsync(CreateUpdateArticleDto input)
        {
            var article = new Article(GuidGenerator.Create(), CurrentUser.GetId(), input.Title, input.Origin, input.Auth, input.Thumbnail, input.Descritpion, input.File, input.Video);

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

            if (input.CreationTime.HasValue)
                article.SetCreationTime(input.CreationTime.Value);

            // 图片
            if (input.Pictures?.Count > 0)
            {
                foreach (var pictureUrl in input.Pictures)
                    article.AddPicture(pictureUrl);
            }

            // 详细
            if (input.Contents?.Count > 0)
            {
                foreach (KeyValuePair<string, string> kv in input.Contents)
                    article.AddContent(kv.Key, kv.Value);
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

        public async Task<ArticleDto> UpdateAsync(Guid id, CreateUpdateArticleDto input)
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

            if (input.CreationTime.HasValue)
                article.SetCreationTime(input.CreationTime.Value);

            // 图片
            if (input.Pictures == null || input.Pictures.Count == 0)
            {
                article.Pictures.Clear();
            }
            else
            {
                article.Pictures.RemoveAll(x => !input.Pictures.Contains(x.PictureUrl));

                foreach (var pictureUrl in input.Pictures)
                    article.AddPicture(pictureUrl);
            }

            // 内容
            if (input.Contents == null || input.Contents.Count == 0)
            {
                article.Contents.Clear();
            }
            else
            {
                article.Contents.RemoveAll(x => !input.Contents.Keys.Contains(x.Key));

                foreach (KeyValuePair<string, string> kv in input.Contents)
                    article.AddContent(kv.Key, kv.Value);
            }

            // 绑定目录
            if (input.Categories == null || input.Categories.Count == 0)
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
            if (input.Tags == null || input.Tags.Count == 0)
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

            var result = await _logManager.WriteAsync(article.Id, input.Status, input.Remark);

            return ObjectMapper.Map<ArticleAuditLog, ArticleAuditLogDto>(result);
        }
    
        /// <summary>
        /// Article -> ArticleViewDto
        /// </summary>
        /// <param name="articles"></param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        private async Task<List<ArticleViewDto>> MapArticleViewDto(List<Article> articles, bool includeDetails = true)
        {
            var result = ObjectMapper.Map<List<Article>, List<ArticleViewDto>>(articles);

            if (includeDetails)
            {
                //var categoryIds = new List<Guid>();
                var tagIds = new List<Guid>();
                // 找出所有的分类id和tag id
                foreach (var item in articles)
                {
                    //if (item.Categories?.Count > 0)
                    //    categoryIds.AddRange(item.Categories.Select(x => x.CategoryId));

                    if (item.Tags?.Count > 0)
                        tagIds.AddRange(item.Tags.Select(x => x.TagId));
                }
                // 找出分类和tag的详细
                //var categories = await _categoryRepository.GetByIdsAsync(categoryIds.Distinct().ToList());
                var tags = await _tagRepository.GetByIdsAsync(tagIds.Distinct().ToList());
                // 补全复合类型内容
                foreach (var item in articles)
                {
                    var article = result.FirstOrDefault(x => x.Id == item.Id);
                    // 分类
                    //foreach(var cat in item.Categories)
                    //{
                    //    var category = categories.FirstOrDefault(x => x.Id == cat.CategoryId);
                    //    if (category != null)
                    //        article.Categories.Add(ObjectMapper.Map<Category, CategoryViewDto>(category));
                    //}
                    article.Categories = item.Categories.Select(x => x.CategoryId).ToList();
                    // Tags
                    foreach (var t in item.Tags)
                    {
                        var tag = tags.FirstOrDefault(x => x.Id == t.TagId);
                        if (tag != null)
                            article.Tags.Add(tag.Name);
                            //article.Tags.Add(ObjectMapper.Map<Tag, TagDto>(tag));
                    }
                    // 详细
                    foreach (var t in item.Contents)
                    {
                        article.Contents.Add(t.Key, t.Content);
                    }
                    // 图片
                    foreach (var t in item.Pictures)
                    {
                        article.Pictures.Add(t.PictureUrl);
                    }
                }
            }

            return result;
        }
    }
}
