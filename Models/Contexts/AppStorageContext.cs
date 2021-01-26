using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FilmsCatalog.Models.Contexts
{
    public class AppStorageContext : DbContext
    {
        DbSet<UserModel> Users { get; set; }
        DbSet<FilmModel> Films { get; set; }
        DbSet<PosterModel> Posters { get; set; }

        public AppStorageContext(DbContextOptions<AppStorageContext> options) : base (options)
        {
            Database.EnsureCreated();
        }
    }
}
