using System;
using System.Threading.Tasks;
using Lazy.Abp.Cms.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.Cms
{
    public interface ITagAppService : IApplicationService, ITransientDependency
    {
        Task<PagedResultDto<TagDto>> GetListAsync(GetTagListRequestDto input);

        Task<int> IncHits(Guid id);
    }
}