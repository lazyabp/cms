using System;
using System.ComponentModel;
namespace Lazy.Abp.Cms.Dtos
{
    [Serializable]
    public class CreateUpdateTagDto
    {
        public string Name { get; set; }

        public int Hits { get; set; }
    }
}