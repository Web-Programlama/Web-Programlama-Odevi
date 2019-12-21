using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proje.Data;
using Proje.Models;

namespace Proje.Pages.Admin.Category
{
    public class IndexModel : PageModel
    {
        private readonly Proje.Data.ApplicationDbContext _context;

        public IndexModel(Proje.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
