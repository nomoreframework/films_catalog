using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FilmsCatalog.Models.Contexts
{
    public class AppStorageContext : DbContext
    {
       public DbSet<UserModel> Users { get; set; }
       public DbSet<FilmModel> Films { get; set; }
       public DbSet<PosterModel> Posters { get; set; }

        public AppStorageContext(DbContextOptions<AppStorageContext> options) : base (options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
