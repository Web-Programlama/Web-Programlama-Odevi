using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Proje.Models
{
    public class Comment
    {
        public int ID { get; set; }

        public int ContentID { get; set; }

        [ForeignKey("ContentID")]
        public virtual Content Content { get; set; }

        public string CommentContent { get; set; }

        public DateTime CommentTime { get; set; }

        public double CommentRating { get; set; }

        public string ReaderID { get; set; }

        [ForeignKey("ReaderID")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
