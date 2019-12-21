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
    public class DeleteModel : PageModel
    {
        private readonly Proje.Data.ApplicationDbContext _context;

        public DeleteModel(Proje.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Proje.Models.Content Content { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Content = await _context.Content
                .Include(c => c.Category).FirstOrDefaultAsync(m => m.ID == id);

            if (Content == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Content = await _context.Content.FindAsync(id);

            if (Content != null)
            {
                _context.Content.Remove(Content);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
