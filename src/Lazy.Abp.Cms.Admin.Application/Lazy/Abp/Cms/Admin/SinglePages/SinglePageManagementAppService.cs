using Lazy.Abp.Cms.Admin.Permissions;
using Lazy.Abp.Cms.SinglePages;
using Lazy.Abp.Cms.SinglePages.Dtos;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Cms.Admin.SinglePages
{
    public class SinglePageManagementAppService : CrudAppService<SinglePage, SinglePageDto, Guid, SinglePageListRequestDto, SinglePageCreateUpdateDto, SinglePageCreateUpdateDto>,
        ISinglePageManagementAppService
    {
        protected override string GetPolicyName { get; set; } = CmsAdminPermissions.SinglePage.Default;
        protected override string GetListPolicyName { get; set; } = CmsAdminPermissions.SinglePage.Default;
        protected override string CreatePolicyName { get; set; } = CmsAdminPermissions.SinglePage.Create;
        protected override string UpdatePolicyName { get; set; } = CmsAdminPermissions.SinglePage.Update;
        protected override string DeletePolicyName { get; set; } = CmsAdminPermissions.SinglePage.Delete;

        private readonly ISinglePageRepository _repository;
        
        public SinglePageManagementAppService(ISinglePageRepository repository) : base(repository)
        {
            _repository = repository;
        }

        [Authorize(CmsAdminPermissions.SinglePage.Default)]
        public override async Task<PagedResultDto<SinglePageDto>> GetListAsync(SinglePageListRequestDto input)
        {
            var totalCount = await _repository.GetCountAsync(input.CreatedAfter, input.CreatedBefore, input.Filter);
            var list = await _repository.GetListAsync(input.MaxResultCount, input.SkipCount, input.Sorting, input.CreatedAfter, input.CreatedBefore, input.Filter);

            return new PagedResultDto<SinglePageDto>(
                totalCount,
                ObjectMapper.Map<List<SinglePage>, List<SinglePageDto>>(list)
            );
        }
    }
}
