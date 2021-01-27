using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
namespace FilmsCatalog.Models
{
    interface IUser<U> where U : UserRegisterModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string SurName { get; set; }
        string FullName { get; set; }
        string Password { get; set; }
        string Email { get; set; }
    }
}
