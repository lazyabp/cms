using Lazy.Abp.Cms.Tags.Dtos;
using System;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Cms.Admin.Tags
{
    public interface ITagManagementAppService :
        ICrudAppService< 
            TagDto, 
            Guid,
            TagListRequestDto,
            TagCreateUpdateDto,
            TagCreateUpdateDto>
    {

    }
}