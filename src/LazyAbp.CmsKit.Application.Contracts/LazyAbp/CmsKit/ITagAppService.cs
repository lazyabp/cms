using System;
using System.Threading.Tasks;
using LazyAbp.CmsKit.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace LazyAbp.CmsKit
{
    public interface ITagAppService : IApplicationService, ITransientDependency
    {
        Task<PagedResultDto<TagDto>> GetListAsync(GetTagListRequestDto input);

        Task<int> IncHits(Guid id);
    }
}