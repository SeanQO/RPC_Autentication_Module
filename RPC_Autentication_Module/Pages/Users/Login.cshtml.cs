using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
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

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.Out.WriteLine("HWELLLOo");
            if (!ModelState.IsValid) return Page();

            if (credential.UserName == "admin" && credential.Password == "admin")
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, credential.UserName)
                };

                var identity = new ClaimsIdentity(claims, "CookieAuth");

                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("CookieAuth", claimsPrincipal);


                return RedirectToPage("Index");
            }

            return Page();
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