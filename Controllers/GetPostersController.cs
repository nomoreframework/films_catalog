using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using FilmsCatalog.Models;
using FilmsCatalog.Models.Contexts;
using Microsoft.AspNetCore.Authorization;

namespace FilmsCatalog.Controllers
{
    [Authorize]
    public class GetPostersController : Controller
    {
        AppStorageContext context;

        public GetPostersController(AppStorageContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public IActionResult AddFilm()
        {

            return View(User.Identity.Name);
        }
        [HttpPost]
        public async Task<IActionResult> AddFilm(FilmModel fm)
        {
            PosterModel person = new PosterModel();
            if (ModelState.IsValid)
            {
                if (fm.PosterView != null)
                {
                    byte[] imageData = null;
                    // считываем переданный файл в массив байтов
                    using (var binaryReader = new BinaryReader(fm.PosterView.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)fm.PosterView.Length);
                    }
                    // установка массива байтов

                }
               await context.Posters.AddAsync(person);
                context.SaveChanges();
            }

            return View(fm);
        }
    }
}
