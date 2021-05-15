using Lazy.Abp.Cms.Categories.Dtos;
using System;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Cms.Admin
{
    public interface ICategoryManagementAppService :
        ICrudAppService< 
            CategoryDto, 
            Guid,
            GetCategoryListRequestDto,
            CreateUpdateCategoryDto,
            CreateUpdateCategoryDto>
    {

    }
}