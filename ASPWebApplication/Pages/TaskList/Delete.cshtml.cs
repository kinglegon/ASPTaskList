using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASPWebApplication.Models;

namespace ASPWebApplication.Pages.TaskList
{
    public class DeleteModel : PageModel
    {
        private readonly ASPWebApplication.Models.ASPWebAppDBContext _context;

        public DeleteModel(ASPWebApplication.Models.ASPWebAppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tasks Tasks { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tasks = await _context.Tasks
                .Include(t => t.Person).FirstOrDefaultAsync(m => m.TaskId == id);

            if (Tasks == null)
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

            Tasks = await _context.Tasks.FindAsync(id);

            if (Tasks != null)
            {
                _context.Tasks.Remove(Tasks);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
