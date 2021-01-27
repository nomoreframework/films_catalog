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

        public async Task<IActionResult> Index() => View( await context.Films?.Include(f => f.Poster).ToListAsync());

        public IActionResult Privacy() => View();
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() =>  View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}
