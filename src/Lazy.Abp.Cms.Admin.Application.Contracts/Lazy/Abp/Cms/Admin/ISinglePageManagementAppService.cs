using Lazy.Abp.Cms.SinglePages.Dtos;
using System;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Cms.Admin
{
    public interface ISinglePageManagementAppService :
        ICrudAppService< 
            SinglePageDto, 
            Guid,
            GetSinglePageListRequestDto,
            CreateUpdateSinglePageDto,
            CreateUpdateSinglePageDto>
    {

    }
}