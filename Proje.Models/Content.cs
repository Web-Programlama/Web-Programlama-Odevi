using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Proje.Models
{
   public class Content
    {
        [Key]
        public int ID { get; set; }

        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        public DateTime ContentTime { get; set; }
        public string ContentName { get; set; }
        public string ContentDetail { get; set; }
        public bool ContentState { get; set; }
        public string ContentKeywords { get; set; }
        public int ContentHit { get; set; }
        public string ContentImg { get; set; }
        public string ContentAuthor { get; set; }

    }
}
