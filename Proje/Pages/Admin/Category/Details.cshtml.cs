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
    public class DetailsModel : PageModel
    {
        private readonly Proje.Data.ApplicationDbContext _context;

        public DetailsModel(Proje.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
