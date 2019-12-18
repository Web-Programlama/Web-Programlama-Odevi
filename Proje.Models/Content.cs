using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Models
{
    class Content
    {
        public int ID { get; set; }
        public DateTime ContentTime { get; set; }
        public string ContentImgPath { get; set; }
        public string ContentName { get; set; }
        public string ContentDetail { get; set; }
        public bool ContentState { get; set; }
        public string ContentKeywords { get; set; }
    }
}
