using System;
using Lazy.Abp.Cms.Permissions;
using Lazy.Abp.Cms.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using System.Threading.Tasks;
using Volo.Abp.Users;
using Volo.Abp;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Lazy.Abp.Cms
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

        public async Task<PagedResultDto<UserCategoryDto>> GetListAsync(GetUserCategoryListRequestDto input)
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
        public async Task<UserCategoryDto> CreateAsync(CreateUpdateUserCategoryDto input)
        {
            var category = new UserCategory(GuidGenerator.Create(), CurrentTenant.Id, CurrentUser.GetId(), input.Name, input.DisplayOrder);
            category = await _repository.InsertAsync(category);

            return ObjectMapper.Map<UserCategory, UserCategoryDto>(category);
        }

        [Authorize]
        public async Task<UserCategoryDto> UpdateAsync(Guid id, CreateUpdateUserCategoryDto input)
        {
            var category = await _repository.GetAsync(id);
            if (category.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissions"]);

            category.Update(input.Name, input.DisplayOrder);

            await _repository.UpdateAsync(category);

            return ObjectMapper.Map<UserCategory, UserCategoryDto>(category);
        }

        [Authorize]
        public async Task DeleteAsync(Guid id)
        {
            var category = await _repository.GetAsync(id);
            if (category.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissions"]);

            await _repository.DeleteAsync(category);
        }
    }
}
