using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
namespace FilmsCatalog.Models
{
    interface IUser<U> where U : IdentityUser
    {
        int Id { get; set; }
        string Name { get; set; }
        string SurName { get; set; }
        string FullName { get; set; }
        string registrationDate { get; }

        int UserRegisterId { get; set; }
        U userRegister { get; set; }
        List<FilmModel> Films { get; set; }
    }
}
