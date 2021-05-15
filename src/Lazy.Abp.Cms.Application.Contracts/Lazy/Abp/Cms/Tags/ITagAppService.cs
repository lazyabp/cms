using Lazy.Abp.Cms.Tags.Dtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.Cms.Tags
{
    public interface ITagAppService : IApplicationService, ITransientDependency
    {
        Task<PagedResultDto<TagDto>> GetListAsync(GetTagListRequestDto input);

        Task<int> IncHits(Guid id);
    }
}