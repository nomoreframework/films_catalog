using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FilmsCatalog.Models.Contexts
{
    public class RegisterContext : IdentityDbContext<UserRegisterModel>
    {
    }
}
