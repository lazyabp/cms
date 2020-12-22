using System;
using LazyAbp.CmsKit.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using LazyAbp.CmsKit.Admin.Permissions;

namespace LazyAbp.CmsKit.Admin
{
    public class TagManagementAppService : CrudAppService<Tag, TagDto, Guid, GetTagListRequestDto, CreateUpdateTagDto, CreateUpdateTagDto>,
        ITagManagementAppService
    {
        protected override string GetPolicyName { get; set; } = CmsKitAdminPermissions.Tag.Default;
        protected override string GetListPolicyName { get; set; } = CmsKitAdminPermissions.Tag.Default;
        protected override string CreatePolicyName { get; set; } = CmsKitAdminPermissions.Tag.Create;
        protected override string UpdatePolicyName { get; set; } = CmsKitAdminPermissions.Tag.Update;
        protected override string DeletePolicyName { get; set; } = CmsKitAdminPermissions.Tag.Delete;

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
