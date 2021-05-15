using System;
using Lazy.Abp.Cms.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using Lazy.Abp.Cms.Admin.Permissions;

namespace Lazy.Abp.Cms.Admin
{
    public class TagManagementAppService : CrudAppService<Tag, TagDto, Guid, GetTagListRequestDto, CreateUpdateTagDto, CreateUpdateTagDto>,
        ITagManagementAppService
    {
        protected override string GetPolicyName { get; set; } = CmsAdminPermissions.Tag.Default;
        protected override string GetListPolicyName { get; set; } = CmsAdminPermissions.Tag.Default;
        protected override string CreatePolicyName { get; set; } = CmsAdminPermissions.Tag.Create;
        protected override string UpdatePolicyName { get; set; } = CmsAdminPermissions.Tag.Update;
        protected override string DeletePolicyName { get; set; } = CmsAdminPermissions.Tag.Delete;

        private readonly ITagRepository _repository;
        
        public TagManagementAppService(ITagRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public override async Task<PagedResultDto<TagDto>> GetListAsync(GetTagListRequestDto input)
        {
            var totalCount = await _repository.GetCountAsync();
            var list = await _repository.GetListAsync(input.MaxResultCount, input.SkipCount, input.Sorting, input.Filter);

            return new PagedResultDto<TagDto>(
                totalCount,
                ObjectMapper.Map<List<Tag>, List<TagDto>>(list)
            );
        }
    }
}
