using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASPWebApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPWebApplication.Pages.TaskList
{
    public class IndexModel : PageModel
    {
        private readonly ASPWebApplication.Models.ASPWebAppDBContext _context;
        

        public IndexModel(ASPWebApplication.Models.ASPWebAppDBContext context)
        {
            _context = context;
        }

    
        public IList<Tasks> Tasks { get;set; }

        [BindProperty(SupportsGet = true)]
        public bool Complete { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList CompletedCheckOutput { get; set; }
        [BindProperty(SupportsGet = true)]
        public string CompletedCheck { get; set; } = "Not Completed";
        

        public async Task OnGetAsync()
        {
            if (CompletedCheck != null)
            { 
                var tasks = from t in _context.Tasks
                                        select t;
                try { 
                     if (CompletedCheck.Equals("Completed"))
                     {
                         tasks = tasks.Where(x => x.Completed.Equals(true));
                            
                          Tasks = await tasks
                                 .Include(t => t.Person).ToListAsync();
                     }
                     else if (CompletedCheck.Equals("Not Completed"))
                     {
                           tasks = tasks.Where(x => x.Completed.Equals(false));
            
                            Tasks = await tasks
                               .Include(t => t.Person).ToListAsync();
                     }
                     else
                     {
                     Tasks = await _context.Tasks
                      .Include(t => t.Person).ToListAsync();
                     }

                }

                finally
                {

                }


            }
            else
            {
                Tasks = await _context.Tasks
             .Include(t => t.Person).ToListAsync();
            }

            
        }
    }
}
