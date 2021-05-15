using System;
using System.ComponentModel;

namespace Lazy.Abp.Cms.Tags.Dtos
{
    [Serializable]
    public class CreateUpdateTagDto
    {
        public string Name { get; set; }

        public int Hits { get; set; }
    }
}