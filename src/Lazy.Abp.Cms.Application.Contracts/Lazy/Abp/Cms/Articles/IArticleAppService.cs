using Lazy.Abp.Cms.Articles.Dtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.Cms.Articles
{
    public interface IArticleAppService : IApplicationService, ITransientDependency
    {
        Task<ArticleDto> GetAsync(Guid id);

        Task<ArticleContentDto> GetContentAsync(Guid id);

        Task<PagedResultDto<ArticleDto>> GetListAsync(ArticleListRequestDto input);

        Task<PagedResultDto<ArticleDto>> GetListByTagAsync(string tag);

        Task<PagedResultDto<ArticleDto>> GetListByTagIdAsync(Guid id);

        Task<ArticleDto> CreateAsync(ArticleCreateUpdateDto input);

        Task<ArticleDto> UpdateAsync(Guid id, ArticleCreateUpdateDto input);

        Task DeleteAsync(Guid id);

        Task<int> IncHits(Guid id);

        Task<int> AddLike(Guid id);

        Task<int> RemoveLike(Guid id);

        Task<int> AddDislike(Guid id);

        Task<int> RemoveDislike(Guid id);

        Task<int> AddFavorite(Guid id);

        Task<int> RemoveFavorite(Guid id);

        Task SetActiveAsync(Guid id, SetActiveRequestDto input);
    }
}