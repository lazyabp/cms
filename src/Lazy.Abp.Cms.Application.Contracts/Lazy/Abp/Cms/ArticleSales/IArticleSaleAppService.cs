using Lazy.Abp.Cms.ArticleSales.Dtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.Cms.ArticleSales
{
    public interface IArticleSaleAppService : IApplicationService, ITransientDependency
    {
        Task<ArticleSaleDto> GetAsync(Guid id);

        Task<PagedResultDto<ArticleSaleDto>> GetListAsync(ArticleSalesListRequestDto input);

        Task DeleteAsync(Guid id);
    }
}