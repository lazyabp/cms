using System;
using System.Threading.Tasks;
using Lazy.Abp.Cms.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.Cms
{
    public interface IArticleSaleAppService : IApplicationService, ITransientDependency
    {
        Task<ArticleSaleDto> GetAsync(Guid id);

        Task<PagedResultDto<ArticleSaleDto>> GetListAsync(GetArticleSalesListRequestDto input);

        Task DeleteAsync(Guid id);
    }
}