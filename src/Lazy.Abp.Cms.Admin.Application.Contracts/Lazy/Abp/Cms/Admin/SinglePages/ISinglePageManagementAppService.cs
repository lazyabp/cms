using Lazy.Abp.Cms.SinglePages.Dtos;
using System;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Cms.Admin.SinglePages
{
    public interface ISinglePageManagementAppService :
        ICrudAppService< 
            SinglePageDto, 
            Guid,
            SinglePageListRequestDto,
            SinglePageCreateUpdateDto,
            SinglePageCreateUpdateDto>
    {

    }
}