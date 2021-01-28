using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using FilmsCatalog.Models;
using FilmsCatalog.Models.Contexts;
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
            if (!User.Identity.IsAuthenticated) return BadRequest();
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

        public async Task<IActionResult> Delete(int? id)
        {
            if (!User.Identity.IsAuthenticated) return BadRequest();
            var film = await context.Films.FirstOrDefaultAsync(f => f.Id == id);
            if(film != null)
            {
                context.Films.Remove(film);
                await context.SaveChangesAsync();
                return RedirectToAction("MyFilms","GetPosters");
            }
            return NotFound();
        }
        public async Task<IActionResult> UpdateFilm(int? id)
        {
            var film = await context.Films.Include(f => f.Poster).FirstOrDefaultAsync(f => f.Id == id);
            if (film != null)
            {
                return View(film);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFilm(FilmModel film)
        {
            if (ModelState.IsValid)
            {
                FilmModel filmModel;
                if (film.PosterView != null)
                {
                    byte[] imageData;
                    using (var binaryReader = new BinaryReader(film.PosterView.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)film.PosterView.Length);
                    }
                    filmModel = await context.Films.Include(p =>p.Poster).FirstOrDefaultAsync(f => f.Id == film.Id);
                    filmModel.Poster.Poster = imageData;
                    context.Films.Update(filmModel);
                    await context.SaveChangesAsync();
                    return RedirectToAction("MyFilms", "GetPosters");
                }
            }
            ModelState.AddModelError("", "Uncorrect Description");
            return View(film);
        }
    }
}
