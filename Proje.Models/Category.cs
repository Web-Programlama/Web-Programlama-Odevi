using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proje.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        [Required]
        [Display(Name = "Display Order")]
        public int CategoryOrder { get; set; }
    }
}
