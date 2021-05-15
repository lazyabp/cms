using Lazy.Abp.Cms.ArticleFavorites.Dtos;
using Lazy.Abp.Cms.Articles;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Users;

namespace Lazy.Abp.Cms.ArticleFavorites
{
    public class ArticleFavoriteAppService : CmsAppService, IArticleFavoriteAppService, ITransientDependency
    {
        private readonly IArticleFavoriteRepository _repository;
        private readonly IArticleRepository _articleRepository;

        public ArticleFavoriteAppService(IArticleFavoriteRepository repository,
            IArticleRepository articleRepository)
        {
            _repository = repository;
            _articleRepository = articleRepository;
        }

        public async Task<PagedResultDto<ArticleFavoriteDto>> GetListAsync(GetArticleFavoriteListRequestDto input)
        {
            var totalCount = await _repository.GetCountAsync(CurrentUser.GetId(), null, input.Filter);
            var list = await _repository.GetListAsync(input.MaxResultCount, input.SkipCount, input.Sorting, CurrentUser.GetId(), null, input.Filter);

            return new PagedResultDto<ArticleFavoriteDto>(
                totalCount,
                ObjectMapper.Map<List<ArticleFavorite>, List<ArticleFavoriteDto>>(list)
            );
        }

        [Authorize]
        public async Task DeleteAsync(Guid id)
        {
            var record = await _repository.GetAsync(id, false);
            await _repository.DeleteAsync(record);

            var article = await _articleRepository.GetAsync(id);
            article.SetFavorites(article.FavoriteCount - 1);
        }
    }
}
