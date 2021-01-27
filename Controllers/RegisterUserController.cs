using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using FilmsCatalog.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace FilmsCatalog.Controllers
{
    public class RegisterUserController : Controller
    {
        private readonly UserManager<UserRegisterModel> userManager;
        private readonly SignInManager<UserRegisterModel> signInManager;
            
            public RegisterUserController(UserManager<UserRegisterModel> userManager, SignInManager<UserRegisterModel> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public ActionResult Register()
        {
            return View();
        }
         
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegisterController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
         [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserModel u_s_model)
        {
            if (ModelState.IsValid)
            {
                UserRegisterModel user = new UserRegisterModel{ Email = u_s_model.Email, UserName = u_s_model.Email};
                var result = await userManager.CreateAsync(user, u_s_model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    await Authenticate(u_s_model.Email);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(u_s_model);
        }
        [HttpGet]
        public IActionResult SignIn(string returnUrl = null)
        {
            return View(new UserSignInModel { ReturnUrl = returnUrl });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(UserSignInModel u_s_model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await signInManager.PasswordSignInAsync(u_s_model.Email, u_s_model.Password, u_s_model.RememberMe, false);
                if (result.Succeeded)
                { 
                    if (!string.IsNullOrEmpty(u_s_model.ReturnUrl) && Url.IsLocalUrl(u_s_model.ReturnUrl))
                    {
                        return Redirect(u_s_model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index","Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(u_s_model);
        }
        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
