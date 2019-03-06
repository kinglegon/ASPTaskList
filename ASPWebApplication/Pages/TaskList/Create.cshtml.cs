using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASPWebApplication.Models;

namespace ASPWebApplication.Pages.TaskList
{
    public class CreateModel : PageModel
    {
        private readonly ASPWebApplication.Models.ASPWebAppDBContext _context;

        public CreateModel(ASPWebApplication.Models.ASPWebAppDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Tasks = new Tasks
            {
                TaskDate = DateTime.Now
            };

            ViewData["PersonId"] = new SelectList(_context.People, "PersonId", "FirstName");

            return Page();
        }

        [BindProperty]
        public Tasks Tasks { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tasks.Add(Tasks);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}