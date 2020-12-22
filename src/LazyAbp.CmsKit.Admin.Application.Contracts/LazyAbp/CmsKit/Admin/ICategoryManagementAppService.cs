using System;
using LazyAbp.CmsKit.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.CmsKit.Admin
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