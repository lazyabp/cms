using System;
using System.Threading.Tasks;
using Lazy.Abp.Cms.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.Cms
{
    public interface ISinglePageAppService : IApplicationService, ITransientDependency
    {
        Task<SinglePageDto> GetAsync(Guid id);

        Task<SinglePageDto> GetByName(string name);

        Task<PagedResultDto<SinglePageDto>> GetListAsync(GetSinglePageListRequestDto input);
    }
}