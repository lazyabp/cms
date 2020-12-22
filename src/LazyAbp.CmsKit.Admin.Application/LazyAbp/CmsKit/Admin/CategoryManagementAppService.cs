using System;
using LazyAbp.CmsKit.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Uow;
using LazyAbp.CmsKit.Admin.Permissions;

namespace LazyAbp.CmsKit.Admin
{
    public class CategoryManagementAppService : CrudAppService<Category, CategoryDto, Guid, GetCategoryListRequestDto, CreateUpdateCategoryDto, CreateUpdateCategoryDto>,
        ICategoryManagementAppService
    {
        protected override string GetPolicyName { get; set; } = CmsKitAdminPermissions.Category.Default;
        protected override string GetListPolicyName { get; set; } = CmsKitAdminPermissions.Category.Default;
        protected override string CreatePolicyName { get; set; } = CmsKitAdminPermissions.Category.Create;
        protected override string UpdatePolicyName { get; set; } = CmsKitAdminPermissions.Category.Update;
        protected override string DeletePolicyName { get; set; } = CmsKitAdminPermissions.Category.Delete;

        private readonly ICategoryRepository _repository;
        
        public CategoryManagementAppService(ICategoryRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public override async Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input)
        {
            var depth = 1;
            var id = GuidGenerator.Create();
            var path = id.ToString();

            Guid? rootId = null;

            if (input.ParentId.HasValue)
            {
                var parent = await _repository.GetAsync(input.ParentId.Value);
                if (parent == null)
                    throw new UserFriendlyException(L["ParentCategoryNotExist"]);

                rootId = parent.ParentId.HasValue ? parent.RootId : parent.Id;
                path = parent.ParentId.HasValue ? parent.Path + "," + id.ToString() : parent.Id + "," + id.ToString();
                depth = parent.Depth + 1;
            }

            var category = new Category(id, input.Name, input.Label, depth, input.ParentId, rootId, path, input.DisplayOrder);
            category = await _repository.InsertAsync(category);

            return ObjectMapper.Map<Category, CategoryDto>(category);
        }

        public override async Task<CategoryDto> UpdateAsync(Guid id, CreateUpdateCategoryDto input)
        {
            var depth = 1;
            var path = id.ToString();
            Guid? rootId = null;

            if (input.ParentId.HasValue)
            {
                var parent = await _repository.GetAsync(input.ParentId.Value);
                if (parent == null)
                    throw new UserFriendlyException(L["ParentCategoryNotExist"]);

                rootId = parent.ParentId.HasValue ? parent.RootId : parent.Id;
                path = parent.ParentId.HasValue ? parent.Path + "," + id.ToString() : parent.Id + "," + id.ToString();
                depth = parent.Depth + 1;
            }

            var category = await _repository.GetAsync(id);
            var oldParentId = category.ParentId;

            category.Update(input.Name, input.Label, depth, input.ParentId, rootId, path, input.DisplayOrder);
            category = await _repository.UpdateAsync(category);

            // 更新所有子分类
            if (oldParentId != input.ParentId)
                await UpdateChildTree(category);

            return ObjectMapper.Map<Category, CategoryDto>(category);
        }

        private async Task UpdateChildTree(Category parent)
        {
            var childrens = await _repository.GetByParentIdAsync(parent.Id);
            foreach(var children in childrens)
            {
                children.SetDepath(parent.Depth + 1);

                if (parent.ParentId.HasValue)
                {
                    children.SetRoot(parent.RootId);
                    children.SetPath(parent.Path + "," + children.Id.ToString());
                }
                else
                {
                    children.SetRoot(parent.Id);
                    children.SetPath(parent.Id + "," + children.Id.ToString());
                }

                await _repository.UpdateAsync(children);
                // 递归更新
                await UpdateChildTree(children);
            }
        }
    }
}
