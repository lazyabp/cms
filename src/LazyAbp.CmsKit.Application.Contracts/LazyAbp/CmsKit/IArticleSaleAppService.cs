using System;
using System.Threading.Tasks;
using LazyAbp.CmsKit.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace LazyAbp.CmsKit
{
    public interface IArticleSaleAppService : IApplicationService, ITransientDependency
    {
        Task<ArticleSaleDto> GetAsync(Guid id);

        Task<PagedResultDto<ArticleSaleDto>> GetListAsync(GetArticleSalesListRequestDto input);

        Task DeleteAsync(Guid id);
    }
}