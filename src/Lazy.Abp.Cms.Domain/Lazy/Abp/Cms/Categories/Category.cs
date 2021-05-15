using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Lazy.Abp.Cms
{
    public class Category : FullAuditedAggregateRoot<Guid>
    {
        [MaxLength(CategoryConsts.MaxNameLength)]
        public virtual string Name { get; protected set; }

        [MaxLength(CategoryConsts.MaxLabelLength)]
        public virtual string Label { get; protected set; }

        public virtual int Depth { get; protected set; }

        public virtual Guid? ParentId { get; protected set; }

        public virtual Guid? RootId { get; protected set; }

        public virtual string Path { get; protected set; }

        public virtual string ListTemplateName { get; protected set; }

        public virtual string DetailTemplateName { get; protected set; }

        public virtual bool IsActive { get; protected set; }

        public virtual int DisplayOrder { get; protected set; }

        protected Category()
        {
        }

        public Category(
            Guid id, 
            string name, 
            string label, 
            int depth, 
            Guid? parentId, 
            Guid? rootId,
            string path,
            int displayOrder
        ) : base(id)
        {
            Name = name;
            Label = label;
            Depth = depth;
            ParentId = parentId;
            RootId = rootId;
            Path = path;
            DisplayOrder = displayOrder;
        }

        public void Update(
            string name,
            string label,
            int depth,
            Guid? parentId,
            Guid? rootId,
            string path,
            int displayOrder
        )
        {
            Name = name;
            Label = label;
            Depth = depth;
            ParentId = parentId;
            RootId = rootId;
            Path = path;
            DisplayOrder = displayOrder;
        }

        public void SetDepath(int depth)
        {
            Depth = depth;
        }

        public void SetRoot(Guid? rootId)
        {
            RootId = rootId;
        }

        public void SetPath(string path)
        {
            Path = path;
        }

        public void SetIsActive(bool isActive)
        {
            IsActive = isActive;
        }

        public void SetListTemplateName(string listTemplateName)
        {
            ListTemplateName = listTemplateName;
        }

        public void SetDetailTemplateName(string detailTemplateName)
        {
            DetailTemplateName = detailTemplateName;
        }
    }
}
