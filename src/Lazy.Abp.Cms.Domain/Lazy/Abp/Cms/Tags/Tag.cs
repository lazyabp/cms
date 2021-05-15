using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Lazy.Abp.Cms.Tags
{
    public class Tag : AggregateRoot<Guid>
    {
        [MaxLength(ArticleConsts.MaxTagNameLength)]
        public virtual string Name { get; protected set; }

        public virtual int Hits { get; protected set; }

        protected Tag()
        {
        }

        public Tag(
            Guid id, 
            string name, 
            int hits
        ) : base(id)
        {
            Name = name;
            Hits = hits;
        }

        public void IncHits()
        {
            Hits++;
        }
    }
}
