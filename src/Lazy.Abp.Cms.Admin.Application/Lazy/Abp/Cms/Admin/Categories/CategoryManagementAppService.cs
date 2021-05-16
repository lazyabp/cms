using Lazy.Abp.Cms.Admin.Permissions;
using Lazy.Abp.Cms.Categories;
using Lazy.Abp.Cms.Categories.Dtos;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Cms.Admin.Categories
{
    public class CategoryManagementAppService : CrudAppService<Category, CategoryDto, Guid, CategoryListRequestDto, CategoryCreateUpdateDto, CategoryCreateUpdateDto>,
        ICategoryManagementAppService
    {
        protected override string GetPolicyName { get; set; } = CmsAdminPermissions.Category.Default;
        protected override string GetListPolicyName { get; set; } = CmsAdminPermissions.Category.Default;
        protected override string CreatePolicyName { get; set; } = CmsAdminPermissions.Category.Create;
        protected override string UpdatePolicyName { get; set; } = CmsAdminPermissions.Category.Update;
        protected override string DeletePolicyName { get; set; } = CmsAdminPermissions.Category.Delete;

        private readonly ICategoryRepository _repository;
        
        public CategoryManagementAppService(ICategoryRepository repository) : base(repository)
        {
            _repository = repository;
        }

        [Authorize(CmsAdminPermissions.Category.Create)]
        public override async Task<CategoryDto> CreateAsync(CategoryCreateUpdateDto input)
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

            var category = new Category(id, input.Name, input.DisplayName, depth, input.ParentId, rootId, path, input.DisplayOrder);
            category = await _repository.InsertAsync(category);

            return ObjectMapper.Map<Category, CategoryDto>(category);
        }

        [Authorize(CmsAdminPermissions.Category.Update)]
        public override async Task<CategoryDto> UpdateAsync(Guid id, CategoryCreateUpdateDto input)
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

            category.Update(input.Name, input.DisplayName, depth, input.ParentId, rootId, path, input.DisplayOrder);
            category = await _repository.UpdateAsync(category);

            // ���������ӷ���
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
                // �ݹ����
                await UpdateChildTree(children);
            }
        }
    }
}
