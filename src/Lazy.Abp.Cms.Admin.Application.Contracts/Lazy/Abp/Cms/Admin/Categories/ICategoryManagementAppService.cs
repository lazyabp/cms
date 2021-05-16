using Lazy.Abp.Cms.Categories.Dtos;
using System;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Cms.Admin.Categories
{
    public interface ICategoryManagementAppService :
        ICrudAppService< 
            CategoryDto, 
            Guid,
            CategoryListRequestDto,
            CategoryCreateUpdateDto,
            CategoryCreateUpdateDto>
    {

    }
}