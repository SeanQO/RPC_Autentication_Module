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
    public class IndexModel : PageModel
    {
        private readonly RPC_Autentication_Module.Data.RPC_Autentication_ModuleContext _context;

        public IndexModel(RPC_Autentication_Module.Data.RPC_Autentication_ModuleContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; }

        public async Task OnGetAsync()
        {
            User = await _context.User.ToListAsync();
        }
    }
}
