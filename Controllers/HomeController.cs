      using FilmsCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FilmsCatalog.Models.Contexts;
using Microsoft.EntityFrameworkCore;
using FilmsCatalog.Models.PaginationModels;

namespace FilmsCatalog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        AppStorageContext context;

        public HomeController(ILogger<HomeController> logger, AppStorageContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public async Task<IActionResult> Index(int? film, string name, int page = 1,
            SortState sortOrder = SortState.NameAsc)
        {
            int pageSize = 3;

            IQueryable<FilmModel> films = context.Films.Include(f => f.Poster);

            if (film != null && film != 0)
            {
                films = films.Where(f => f.Id == film);
            }
            if (!String.IsNullOrEmpty(name))
            {
                films = films.Where(p => p.Name.Contains(name));
            }
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    films = films.OrderByDescending(f => f.Name);
                    break;
                case SortState.YearOfIssueAsc:
                    films = films.OrderBy(d => d.YearOfIssue);
                    break;
                case SortState.YearOfIssueDesc:
                    films = films.OrderByDescending(f => f.YearOfIssue);
                    break;
                default:
                    films = films.OrderBy(s => s.Name);
                    break;
            }
            // пагинация
            var count = await films.CountAsync();
            var items = await films.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            MetaViewModel metaViewModel = new MetaViewModel
            {
                PaginViewModel = new PagineViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterModelView(context.Films.ToList(), film, name),
                FilmModels = items
            };

            return View(metaViewModel);
        }

        public IActionResult Privacy() => View();
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() =>  View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}
