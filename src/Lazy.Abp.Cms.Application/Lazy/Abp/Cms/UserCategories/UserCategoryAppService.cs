using Lazy.Abp.Cms.UserCategories.Dtos;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Users;

namespace Lazy.Abp.Cms.UserCategories
{
    public class UserCategoryAppService : CmsAppService, IUserCategoryAppService, ITransientDependency
    {
        private readonly IUserCategoryRepository _repository;
        
        public UserCategoryAppService(IUserCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserCategoryDto> GetAsync(Guid id)
        {
            var category = await _repository.GetAsync(id);
            if (category.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissions"]);

            return ObjectMapper.Map<UserCategory, UserCategoryDto>(category);
        }

        public async Task<PagedResultDto<UserCategoryDto>> GetListAsync(UserCategoryListRequestDto input)
        {
            var userId = input.UserId ?? CurrentUser.GetId();

            var totalCount = await _repository.GetCountAsync(userId, input.Filter);
            var list = await _repository.GetListAsync(input.MaxResultCount, input.SkipCount, input.Sorting, userId, input.Filter);

            return new PagedResultDto<UserCategoryDto>(
                totalCount,
                ObjectMapper.Map<List<UserCategory>, List<UserCategoryDto>>(list)
            );
        }

        [Authorize]
        public async Task<UserCategoryDto> CreateAsync(UserCategoryCreateUpdateDto input)
        {
            var category = new UserCategory(GuidGenerator.Create(), CurrentTenant.Id, CurrentUser.GetId(), input.Name, input.DisplayOrder);
            category = await _repository.InsertAsync(category);

            return ObjectMapper.Map<UserCategory, UserCategoryDto>(category);
        }

        [Authorize]
        public async Task<UserCategoryDto> UpdateAsync(Guid id, UserCategoryCreateUpdateDto input)
        {
            var category = await _repository.GetAsync(id);

            category.Update(input.Name, input.DisplayOrder);

            await _repository.UpdateAsync(category);

            return ObjectMapper.Map<UserCategory, UserCategoryDto>(category);
        }

        [Authorize]
        public async Task DeleteAsync(Guid id)
        {
            var category = await _repository.GetAsync(id);

            await _repository.DeleteAsync(category);
        }
    }
}
