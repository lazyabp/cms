using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lazy.Abp.Cms.SinglePages
{
    public class SinglePage : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; protected set; }

        [MaxLength(SinglePageConsts.MaxNameLength)]
        public virtual string Name { get; protected set; }

        [MaxLength(SinglePageConsts.MaxTitleLength)]
        public virtual string Title { get; protected set; }

        [MaxLength(SinglePageConsts.MaxThumbnailLength)]
        public virtual string Thumbnail { get; protected set; }

        public virtual string FullDescription { get; protected set; }

        protected SinglePage()
        {
        }

        public SinglePage(
            Guid id,
            Guid? tenantId,
            string name,
            string title,
            string thumbnail,
            string fullDescription
        ) : base(id)
        {
            TenantId = tenantId;
            Name = name;
            Title = title;
            Thumbnail = thumbnail;
            FullDescription = fullDescription;
        }
    }
}
