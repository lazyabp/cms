using Lazy.Abp.Cms.ArticleSales.Dtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Cms.Admin.ArticleSales
{
    public interface IArticleSaleManagementAppService : IApplicationService
    {
        Task<ArticleSaleDto> GetAsync(Guid id);

        Task<PagedResultDto<ArticleSaleDto>> GetListAsync(ArticleSalesListRequestDto input);

        Task DeleteAsync(Guid id);
    }
}
