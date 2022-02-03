using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RPC_Autentication_Module.Data;
using RPC_Autentication_Module.Models;

namespace RPC_Autentication_Module.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly RPC_Autentication_Module.Data.RPC_Autentication_ModuleContext _context;

        public DetailsModel(RPC_Autentication_Module.Data.RPC_Autentication_ModuleContext context)
        {
            _context = context;
        }

        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.User.FirstOrDefaultAsync(m => m.ID == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
