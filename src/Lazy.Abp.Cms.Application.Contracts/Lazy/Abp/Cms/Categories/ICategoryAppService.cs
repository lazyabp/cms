using Lazy.Abp.Cms.Categories.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.Cms.Categories
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