using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Lazy.Abp.Cms
{
    public class SinglePage : FullAuditedAggregateRoot<Guid>
    {
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
            string name,
            string title, 
            string thumbnail, 
            string fullDescription
        ) : base(id)
        {
            Name = name;
            Title = title;
            Thumbnail = thumbnail;
            FullDescription = fullDescription;
        }
    }
}
