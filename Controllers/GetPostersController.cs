using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using FilmsCatalog.Models;
using FilmsCatalog.Models.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace FilmsCatalog.Controllers
{
   
    public class GetPostersController : Controller
    {
        AppStorageContext context;

        public GetPostersController(AppStorageContext context)
        {
            this.context = context;
        }
        
        public IActionResult AddFilm()
        {
            if (User.Identity.IsAuthenticated) return View();
            return BadRequest();
        }
        
        public async Task<IActionResult> MyFilms()
        {
            //if (!User.Identity.IsAuthenticated) return BadRequest();
           // UserRegisterModel registerModel = await context.RegUsers.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
            var films = context.Films.Include(f => f.Poster).Where(f => f.UserRegisterModel.Email == User.Identity.Name);
            return View(await films.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddFilm(FilmModel fm)
        {
            if (ModelState.IsValid)
            {
                PosterModel poster = new PosterModel();
                FilmModel filmModel;
                var curent_user = await context.RegUsers.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
                if (fm.PosterView != null && curent_user != null)
                {
                    byte[] imageData;
                    using (var binaryReader = new BinaryReader(fm.PosterView.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)fm.PosterView.Length);
                    }
                    poster.Poster = imageData;
                    context.Add(poster);
                    filmModel = new FilmModel()
                    {
                        Name = fm.Name,
                        Director = fm.Director,
                        FilmDescription = fm.FilmDescription,
                        YearOfIssue = fm.YearOfIssue,
                        Poster = poster
                    };
                    context.Add(filmModel);
                    curent_user.Films.Add(filmModel);
                    context.Update(curent_user);
                    context.SaveChanges();
                    context.SaveChanges();
                    return RedirectToAction("MyFilms", "GetPosters");
                }
            }
            else ModelState.AddModelError("","Uncorrect");

            return View(fm);
        }
    }
}
