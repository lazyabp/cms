using Lazy.Abp.Cms.ArticleFavorites;
using Lazy.Abp.Cms.ArticleLikes;
using Lazy.Abp.Cms.Articles.Dtos;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Users;

namespace Lazy.Abp.Cms.Articles
{
    public class ArticleAppService : CmsAppService, IArticleAppService, ITransientDependency
    {
        private readonly IArticleRepository _repository;
        private readonly IArticleContentRepository _articleContentRepository;
        private readonly IArticleFavoriteRepository _articleFavoriteRepository;
        private readonly IArticleLikeRepository _articleLikeRepository;
        private readonly IArticleCommonAppService _articleCommonAppService;

        public ArticleAppService(IArticleRepository repository,
            IArticleContentRepository articleContentRepository,
            IArticleFavoriteRepository articleFavoriteRepository,
            IArticleLikeRepository articleLikeRepository,
            IArticleCommonAppService articleCommonAppService)
        {
            _repository = repository;
            _articleContentRepository = articleContentRepository;
            _articleFavoriteRepository = articleFavoriteRepository;
            _articleLikeRepository = articleLikeRepository;
            _articleCommonAppService = articleCommonAppService;
        }

        public Task<ArticleDto> GetAsync(Guid id)
        {
            return _articleCommonAppService.GetAsync(id);
        }

        public async Task<ArticleContentDto> GetContentAsync(Guid id)
        {
            var content = await _articleContentRepository.GetAsync(x => x.ArticleId == id);

            return ObjectMapper.Map<ArticleContent, ArticleContentDto>(content);
        }

        public Task<PagedResultDto<ArticleDto>> GetListAsync(ArticleListRequestDto input)
        {
            return _articleCommonAppService.GetListAsync(input);
        }

        public Task<PagedResultDto<ArticleDto>> GetListByTagAsync(string tag)
        {
            return _articleCommonAppService.GetListByTagAsync(new ArticleListByTagRequestDto { Tag = tag });
        }

        public Task<PagedResultDto<ArticleDto>> GetListByTagIdAsync(Guid id)
        {
            return _articleCommonAppService.GetListByTagAsync(new ArticleListByTagRequestDto { TagId = id });
        }

        [Authorize]
        public Task<ArticleDto> CreateAsync(ArticleCreateUpdateDto input)
        {
            return _articleCommonAppService.CreateAsync(input);
        }

        [Authorize]
        public async Task<ArticleDto> UpdateAsync(Guid id, ArticleCreateUpdateDto input)
        {
            return await _articleCommonAppService.UpdateAsync(id, input);
        }

        [Authorize]
        public async Task DeleteAsync(Guid id)
        {
            var article = await _repository.GetAsync(id, false);

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
                await _articleLikeRepository.CreateAsync(CurrentTenant.Id, CurrentUser.GetId(), id, true);

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
                await _articleLikeRepository.RemoveAsync(CurrentUser.GetId(), id);

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
                await _articleLikeRepository.CreateAsync(CurrentTenant.Id, CurrentUser.GetId(), id, false);

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
                await _articleLikeRepository.RemoveAsync(CurrentUser.GetId(), id);

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
                await _articleFavoriteRepository.CreateAsync(CurrentTenant.Id, CurrentUser.GetId(), id);

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

            article.SetActive(input.IsActive);
        }
    }
}
