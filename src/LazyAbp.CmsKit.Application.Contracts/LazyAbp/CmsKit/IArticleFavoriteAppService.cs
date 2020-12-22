using System;
using System.Threading.Tasks;
using LazyAbp.CmsKit.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace LazyAbp.CmsKit
{
    public interface IArticleFavoriteAppService : IApplicationService, ITransientDependency
    {
        Task<PagedResultDto<ArticleFavoriteDto>> GetListAsync(GetArticleFavoriteListRequestDto input);

        Task DeleteAsync(Guid id);
    }
}