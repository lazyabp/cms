using System;
using System.ComponentModel;
namespace LazyAbp.CmsKit.Dtos
{
    [Serializable]
    public class CreateUpdateSinglePageDto
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Thumbnail { get; set; }

        public string FullDescription { get; set; }
    }
}