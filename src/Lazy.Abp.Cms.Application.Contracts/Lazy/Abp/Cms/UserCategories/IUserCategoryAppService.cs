using Lazy.Abp.Cms.UserCategories.Dtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.Cms.UserCategories
{
    public interface IUserCategoryAppService : IApplicationService, ITransientDependency
    {
        Task<UserCategoryDto> GetAsync(Guid id);

        Task<PagedResultDto<UserCategoryDto>> GetListAsync(GetUserCategoryListRequestDto input);

        Task<UserCategoryDto> CreateAsync(CreateUpdateUserCategoryDto input);

        Task<UserCategoryDto> UpdateAsync(Guid id, CreateUpdateUserCategoryDto input);

        Task DeleteAsync(Guid id);
    }
}