using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proje.Models;
using Proje.Data;

namespace Proje.Pages.Reader.Contact
{
    public class IndexModel : PageModel
    {
        private readonly Proje.Data.ApplicationDbContext _db;

        public IndexModel(Proje.Data.ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Content> icerik { get; set; }
        public List<Category> kategori { get; set; }
        public List<Proje.Models.Comment> yorum { get; set; }
        public void OnGet()
        {

        }
    }
}