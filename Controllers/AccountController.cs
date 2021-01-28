using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FilmsCatalog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using FilmsCatalog.Models.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FilmsCatalog.Controllers
{
    public class AccountController : Controller
    {
        AppStorageContext context;

        public AccountController(AppStorageContext con)
        {
            context = con;
        }

        public ActionResult Register() =>  View();
        
        [HttpPost]
         [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserModel u_s_model)
        {
            if (ModelState.IsValid)
            {
                UserRegisterModel user = 
                    await context.RegUsers.FirstOrDefaultAsync(u => u.Email == u_s_model.Email);
                if (user == null)
                {
                    context.RegUsers.Add(new UserRegisterModel { Email = u_s_model.Email, Password = u_s_model.Password });
                    await context.SaveChangesAsync();
                    await Authenticate(u_s_model.Email);
                    return RedirectToAction("Index","Home");
                }    
                else  ModelState.AddModelError("", "User with this name already exist");
            }
            else ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            return View(u_s_model);
        }
        [HttpGet]
        public IActionResult LogIn(string returnUrl = null)
        {
            return View(new UserSignInModel { ReturnUrl = returnUrl });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(UserSignInModel u_s_model)
        {
            if (ModelState.IsValid)
            {
                UserRegisterModel user =
                    await context.RegUsers.FirstOrDefaultAsync(u => u.Email == u_s_model.Email && u.Password == u_s_model.Password);

                if (user != null)
                {
                        await Authenticate(u_s_model.Email);
                        return RedirectToAction("MyFilms","GetPosters"); 
                }
                else if(user == null) ModelState.AddModelError("", $"User - {u_s_model.Email} does'nt exist");
                
                else ModelState.AddModelError("", "Uncorect login or password");
            }
            return View(u_s_model);
        }
        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
