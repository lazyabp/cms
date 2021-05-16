using Lazy.Abp.Cms.SinglePages.Dtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.Cms.SinglePages
{
    public interface ISinglePageAppService : IApplicationService, ITransientDependency
    {
        Task<SinglePageDto> GetAsync(Guid id);

        Task<SinglePageDto> GetByName(string name);

        Task<PagedResultDto<SinglePageDto>> GetListAsync(SinglePageListRequestDto input);
    }
}