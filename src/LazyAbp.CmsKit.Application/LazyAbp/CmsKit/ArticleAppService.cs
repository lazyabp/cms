using System;
using LazyAbp.CmsKit.Permissions;
using LazyAbp.CmsKit.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using System.Threading.Tasks;
using System.Collections.Generic;
using Volo.Abp.Users;
using Volo.Abp;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace LazyAbp.CmsKit
{
    public class ArticleAppService : CmsKitAppService, IArticleAppService, ITransientDependency
    {
        private readonly IArticleRepository _repository;
        private readonly IArticleContentRepository _articleContentRepository;
        //private readonly ITagRepository _tagRepository;
        private readonly IArticleFavoriteRepository _articleFavoriteRepository;
        private readonly IArticleLikeRepository _articleLikeRepository;
        private readonly IArticleCommonAppService _articleCommonAppService;

        public ArticleAppService(IArticleRepository repository,
            IArticleContentRepository articleContentRepository,
            //ITagRepository tagRepository,
            IArticleFavoriteRepository articleFavoriteRepository,
            IArticleLikeRepository articleLikeRepository,
            IArticleCommonAppService articleCommonAppService)
        {
            _repository = repository;
            _articleContentRepository = articleContentRepository;
            //_tagRepository = tagRepository;
            _articleFavoriteRepository = articleFavoriteRepository;
            _articleLikeRepository = articleLikeRepository;
            _articleCommonAppService = articleCommonAppService;
        }

        public Task<ArticleViewDto> GetAsync(Guid id)
        {
            return _articleCommonAppService.GetAsync(id);
        }

        public async Task<string> GetContentAsync(Guid id, string key)
        {
            var item = await _articleContentRepository.GetAsync(x => x.ArticleId == id && x.Key == key);

            return item?.Content;
        }

        public Task<PagedResultDto<ArticleViewDto>> GetListAsync(GetArticleListRequestDto input)
        {
            return _articleCommonAppService.GetListAsync(input);
        }

        public Task<PagedResultDto<ArticleViewDto>> GetListByTagAsync(string tag)
        {
            return _articleCommonAppService.GetListByTagAsync(new GetArticleListByTagRequestDto { Tag = tag });
        }

        public Task<PagedResultDto<ArticleViewDto>> GetListByTagIdAsync(Guid id)
        {
            return _articleCommonAppService.GetListByTagAsync(new GetArticleListByTagRequestDto { TagId = id });
        }

        [Authorize]
        public Task<ArticleDto> CreateAsync(CreateUpdateArticleDto input)
        {
            return _articleCommonAppService.CreateAsync(input);
        }

        [Authorize]
        public async Task<ArticleDto> UpdateAsync(Guid id, CreateUpdateArticleDto input)
        {
            var article = await _repository.GetAsync(id, true);
            if (article.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissions"]);

            return await _articleCommonAppService.UpdateAsync(id, input);
        }

        [Authorize]
        public async Task DeleteAsync(Guid id)
        {
            var article = await _repository.GetAsync(id, false);
            if (article.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissions"]);

            await _repository.DeleteAsync(article);
        }

        public async Task<int> IncHits(Guid id)
        {
            var article = await _repository.GetAsync(id, false);
            article.SetHits(article.HitCount + 1);

            return article.HitCount;
        }

        [Authorize]
        public async Task<int> AddLike(Guid id)
        {
            try
            {
                await _articleLikeRepository.CreateAsync(CurrentUser.GetId(), id, true);

                var article = await _repository.GetAsync(id, false);
                article.SetLikes(article.LikeCount + 1);

                return article.LikeCount;
            }
            catch(Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }

        [Authorize]
        public async Task<int> RemoveLike(Guid id)
        {
            try
            {
                await _articleLikeRepository.RemoveAsync(CurrentUser.GetId(), id, true);

                var article = await _repository.GetAsync(id, false);
                article.SetLikes(article.LikeCount - 1);

                return article.LikeCount;
            }
            catch(Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }

        [Authorize]
        public async Task<int> AddDislike(Guid id)
        {
            try
            {
                await _articleLikeRepository.CreateAsync(CurrentUser.GetId(), id, false);

                var article = await _repository.GetAsync(id, false);
                article.SetLikes(article.DislikeCount + 1);

                return article.DislikeCount;
            }
            catch(Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }

        [Authorize]
        public async Task<int> RemoveDislike(Guid id)
        {
            try
            {
                await _articleLikeRepository.RemoveAsync(CurrentUser.GetId(), id, false);

                var article = await _repository.GetAsync(id, false);
                article.SetLikes(article.DislikeCount - 1);

                return article.DislikeCount;
            }
            catch(Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }

        [Authorize]
        public async Task<int> AddFavorite(Guid id)
        {
            try
            {
                await _articleFavoriteRepository.CreateAsync(CurrentUser.GetId(), id);

                var article = await _repository.GetAsync(id, false);
                article.SetFavorites(article.FavoriteCount + 1);

                return article.FavoriteCount;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }

        [Authorize]
        public async Task<int> RemoveFavorite(Guid id)
        {
            try
            {
                await _articleFavoriteRepository.RemoveAsync(CurrentUser.GetId(), id);

                var article = await _repository.GetAsync(id, false);
                article.SetFavorites(article.FavoriteCount - 1);

                return article.FavoriteCount;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }

        [Authorize]
        public async Task SetActiveAsync(Guid id, SetActiveRequestDto input)
        {
            var article = await _repository.GetAsync(id);
            if (article.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissions"]);

            article.SetActive(input.IsActive);
        }
    }
}
