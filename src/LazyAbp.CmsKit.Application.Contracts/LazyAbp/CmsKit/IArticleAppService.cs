using System;
using System.Threading.Tasks;
using LazyAbp.CmsKit.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace LazyAbp.CmsKit
{
    public interface IArticleAppService : IApplicationService, ITransientDependency
    {
        Task<ArticleViewDto> GetAsync(Guid id);

        Task<string> GetContentAsync(Guid id, string key);

        Task<PagedResultDto<ArticleViewDto>> GetListAsync(GetArticleListRequestDto input);

        Task<PagedResultDto<ArticleViewDto>> GetListByTagAsync(string tag);

        Task<PagedResultDto<ArticleViewDto>> GetListByTagIdAsync(Guid id);

        Task<ArticleDto> CreateAsync(CreateUpdateArticleDto input);

        Task<ArticleDto> UpdateAsync(Guid id, CreateUpdateArticleDto input);

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