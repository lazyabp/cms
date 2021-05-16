using Lazy.Abp.Cms.ArticleFavorites.Dtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.Cms.ArticleFavorites
{
    public interface IArticleFavoriteAppService : IApplicationService, ITransientDependency
    {
        Task<PagedResultDto<ArticleFavoriteDto>> GetListAsync(ArticleFavoriteListRequestDto input);

        Task DeleteAsync(Guid id);
    }
}