using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace LazyAbp.CmsKit
{
    public class UserCategory : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; }

        public virtual Guid UserId { get; set; }

        [MaxLength(CategoryConsts.MaxNameLength)]
        public virtual string Name { get; protected set; }

        public virtual int DisplayOrder { get; protected set; }

        protected UserCategory()
        {
        }

        public UserCategory(
            Guid id,
            Guid userId,
            string name,
            int displayOrder
        ) : base(id)
        {
            UserId = userId;
            Name = name;
            DisplayOrder = displayOrder;
        }

        public void Update(string name, int displayOrder)
        {
            Name = name;
            DisplayOrder = displayOrder;
        }
    }
}
