using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lazy.Abp.Cms.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.Cms
{
    public interface ICategoryAppService : IApplicationService, ITransientDependency
    {
        Task<CategoryDto> GetAsync(Guid id);

        Task<List<CategoryDto>> GetByRootAsync(Guid? id);

        Task<List<CategoryDto>> GetByParentAsync(Guid? id);

        Task<List<CategoryDto>> GetPathAsync(Guid id);

        Task<PagedResultDto<CategoryDto>> GetListAsync(GetCategoryListRequestDto input);
    }
}