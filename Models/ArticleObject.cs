using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudSurf.Models
{
    public class ArticleObject
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ImgSrc { get; set; }
        public List<Section> Sections { get; set; } = new List<Section>();

        public class Section
        {
            public string Title { get; set; }
            public IEnumerable<string> Paragraphs { get; set; }
        }
    }

   
}
