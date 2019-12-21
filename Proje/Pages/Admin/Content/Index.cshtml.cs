using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proje.Data;
using Proje.Models;

namespace Proje.Pages.Admin.Content
{
    public class IndexModel : PageModel
    {
        private readonly Proje.Data.ApplicationDbContext _context;

        public IndexModel(Proje.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Proje.Models.Content> Content { get;set; }

        public async Task OnGetAsync()
        {
            Content = await _context.Content
                .Include(c => c.Category).ToListAsync();
        }
    }
}
