using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FilmsCatalog.Models.Contexts
{
    public class RegisterContext : IdentityDbContext<UserRegisterModel>
    {
        public RegisterContext(DbContextOptions<RegisterContext> options)
            : base(options)
        {
          //  Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
