using System;
using Lazy.Abp.Cms.Dtos;
using Volo.Abp.Application.Dtos;
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