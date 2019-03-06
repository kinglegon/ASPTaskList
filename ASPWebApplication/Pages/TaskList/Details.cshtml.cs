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
    public class DetailsModel : PageModel
    {
        private readonly ASPWebApplication.Models.ASPWebAppDBContext _context;

        public DetailsModel(ASPWebApplication.Models.ASPWebAppDBContext context)
        {
            _context = context;
        }

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
    }
}
