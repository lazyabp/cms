using System;
using System.Threading.Tasks;
using Lazy.Abp.Cms.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.Cms
{
    public interface IArticleFavoriteAppService : IApplicationService, ITransientDependency
    {
        Task<PagedResultDto<ArticleFavoriteDto>> GetListAsync(GetArticleFavoriteListRequestDto input);

        Task DeleteAsync(Guid id);
    }
}