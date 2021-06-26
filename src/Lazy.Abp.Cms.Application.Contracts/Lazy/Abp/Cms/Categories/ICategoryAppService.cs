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

        Task<List<CategoryViewDto>> GetByRootAsync(Guid? id);

        Task<List<CategoryViewDto>> GetByParentAsync(Guid? id);

        Task<List<CategoryViewDto>> GetPathAsync(Guid id);

        Task<ListResultDto<CategoryViewDto>> GetAll();

        Task<PagedResultDto<CategoryViewDto>> GetListAsync(CategoryListRequestDto input);
    }
}