using System;
using Lazy.Abp.Cms.Permissions;
using Lazy.Abp.Cms.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using System.Threading.Tasks;
using Volo.Abp.Users;
using Volo.Abp;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Lazy.Abp.Cms
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
            var totalCount = await _repository.GetCountAsync(CurrentUser.GetId(), null, input.Filter, input.IncludeDetails);
            var list = await _repository.GetListAsync(input.MaxResultCount, input.SkipCount, input.Sorting, CurrentUser.GetId(), null, input.Filter, input.IncludeDetails);

            return new PagedResultDto<ArticleFavoriteDto>(
                totalCount,
                ObjectMapper.Map<List<ArticleFavorite>, List<ArticleFavoriteDto>>(list)
            );
        }

        [Authorize]
        public async Task DeleteAsync(Guid id)
        {
            var record = await _repository.GetAsync(id, false);
            if (record.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissions"]);

            await _repository.DeleteAsync(record);

            var article = await _articleRepository.GetAsync(id);
            article.SetFavorites(article.FavoriteCount - 1);
        }
    }
}
