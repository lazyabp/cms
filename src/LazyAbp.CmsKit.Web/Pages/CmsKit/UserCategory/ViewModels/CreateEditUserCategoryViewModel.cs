using System;

using System.ComponentModel.DataAnnotations;

namespace LazyAbp.CmsKit.Web.Pages.CmsKit.UserCategory.ViewModels
{
    public class CreateEditUserCategoryViewModel
    {
        [Display(Name = "UserCategoryName")]
        public string Name { get; set; }

        [Display(Name = "UserCategoryLevel")]
        public int Level { get; set; }

        [Display(Name = "UserCategoryParentId")]
        public Guid ParentId { get; set; }
    }
}