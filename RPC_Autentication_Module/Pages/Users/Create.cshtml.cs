using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RPC_Autentication_Module.Data;
using RPC_Autentication_Module.Models;

namespace RPC_Autentication_Module.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly RPC_Autentication_Module.Data.RPC_Autentication_ModuleContext _context;

        public CreateModel(RPC_Autentication_Module.Data.RPC_Autentication_ModuleContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.User.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
