using System;
using Lazy.Abp.Cms.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Cms.Admin
{
    public interface ITagManagementAppService :
        ICrudAppService< 
            TagDto, 
            Guid,
            GetTagListRequestDto,
            CreateUpdateTagDto,
            CreateUpdateTagDto>
    {

    }
}