using Microsoft.EntityFrameworkCore;

namespace FilmsCatalog.Models.Contexts
{
    public class AppStorageContext : DbContext
    {
       public DbSet<UserModel> Users { get; set; }
       public DbSet<UserRegisterModel> RegUsers { get; set; }
       public DbSet<FilmModel> Films { get; set; }
       public DbSet<PosterModel> Posters { get; set; }

        public AppStorageContext(DbContextOptions<AppStorageContext> options) : base (options)
        {
            
        }
    }
}
