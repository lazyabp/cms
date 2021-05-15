using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Cms.Dtos
{
    [Serializable]
    public class UserCategoryDto : FullAuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public int DisplayOrder { get; set; }
    }
}