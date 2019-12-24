using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Proje.Pages.Reader.Home
{
    public class IndexModel : PageModel
    {
        private readonly Proje.Data.ApplicationDbContext _db;
        public IndexModel(Proje.Data.ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Proje.Models.Content> icerik { get; set; }
        public List<Proje.Models.Category> kategori { get; set; }
        public List<Proje.Models.Comment> yorum { get; set; }
        public IList<Proje.Models.Content> Content { get; set; }




        public async Task OnGetAsync()
        {
            icerik = _db.Content.OrderByDescending(x => x.ContentTime).ToList();
            Content = await _db.Content
                .Include(c => c.Category).ToListAsync();
        }
    }
}