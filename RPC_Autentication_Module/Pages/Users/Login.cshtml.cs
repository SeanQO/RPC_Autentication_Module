using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RPC_Autentication_Module.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RPC_Autentication_Module.Pages.Users
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential credential { get; set; }

        private readonly RPC_Autentication_Module.Data.RPC_Autentication_ModuleContext _context;

        public LoginModel(RPC_Autentication_Module.Data.RPC_Autentication_ModuleContext context)
        {
            _context = context;
        }

        private User user;

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            if (validateUser(credential.UserName , credential.Password))
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, credential.UserName)
                };

                var identity = new ClaimsIdentity(claims, "CookieAuth");

                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("CookieAuth", claimsPrincipal);


                return RedirectToPage("Index");
            }

            return Page();
        }

        private Boolean validateUser(String userName, String password) 
        {
            try
            {
                user = _context.User
                    .Where(u => u.Username == userName)
                    .FirstOrDefault();
            }
            catch 
            {
                return false;
            }

            if (user == null) return false;
  
            if(user.Password == password) return true;
 
            return false;        
        }
    }

    public class Credential 
    {
        [Required]
        [Display(Name ="User Name")]
        public String UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        public String Password { get; set; }

    }
}