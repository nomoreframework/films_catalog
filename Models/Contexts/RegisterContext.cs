using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FilmsCatalog.Models;

namespace FilmsCatalog.Models.Contexts
{
    public class RegisterContext : DbContext
    {
        public DbSet<UserRegisterModel> RegUsers { get; set; }
        public RegisterContext(DbContextOptions<RegisterContext> options)
            : base(options)
        {
           
        }
    }
}
