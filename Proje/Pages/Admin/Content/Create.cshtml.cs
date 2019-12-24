using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proje.Data;
using Proje.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Proje.Pages.Admin.Content
{
    public class CreateModel : PageModel
    {
        private readonly Proje.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CreateModel(Proje.Data.ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryID"] = new SelectList(_context.Category, "ID", "CategoryName");
            return Page();
        }

        [BindProperty]
        public Proje.Models.Content Content { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            Content.ContentTime = DateTime.Now;
            Content.ContentHit = 0;
            string fileName = Guid.NewGuid().ToString();
            var uploads = Path.Combine(webRootPath, @"images\content");
            var extension = Path.GetExtension(files[0].FileName);

            using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }
            Content.ContentImg = @"\images\content\" + fileName + extension;
            _context.Content.Add(Content);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
