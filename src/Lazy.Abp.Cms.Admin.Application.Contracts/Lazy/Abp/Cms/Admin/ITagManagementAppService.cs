using Lazy.Abp.Cms.Tags.Dtos;
using System;
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