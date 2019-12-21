using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proje.Data;
using Proje.Models;

namespace Proje.Pages.Admin.Content
{
    public class EditModel : PageModel
    {
        private readonly Proje.Data.ApplicationDbContext _context;

        public EditModel(Proje.Data.ApplicationDbContext context)
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
           ViewData["CategoryID"] = new SelectList(_context.Category, "ID", "CategoryName");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Content).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentExists(Content.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ContentExists(int id)
        {
            return _context.Content.Any(e => e.ID == id);
        }
    }
}
