using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASPWebApplication.Models;

namespace ASPWebApplication.Pages.PeopleList
{
    public class DetailsModel : PageModel
    {
        private readonly ASPWebApplication.Models.ASPWebAppDBContext _context;

        public DetailsModel(ASPWebApplication.Models.ASPWebAppDBContext context)
        {
            _context = context;
        }

        public People People { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            People = await _context.People.FirstOrDefaultAsync(m => m.PersonId == id);

            if (People == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
