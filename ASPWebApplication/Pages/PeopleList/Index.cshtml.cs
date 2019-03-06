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
    public class IndexModel : PageModel
    {
        private readonly ASPWebApplication.Models.ASPWebAppDBContext _context;

        public IndexModel(ASPWebApplication.Models.ASPWebAppDBContext context)
        {
            _context = context;
        }

        public IList<People> People { get;set; }

        public async Task OnGetAsync()
        {
            People = await _context.People.ToListAsync();
        }
    }
}
