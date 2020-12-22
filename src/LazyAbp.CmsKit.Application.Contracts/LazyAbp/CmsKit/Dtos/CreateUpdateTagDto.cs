using System;
using System.ComponentModel;
namespace LazyAbp.CmsKit.Dtos
{
    [Serializable]
    public class CreateUpdateTagDto
    {
        public string Name { get; set; }

        public int Hits { get; set; }
    }
}