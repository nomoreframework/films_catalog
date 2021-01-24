using System.Collections.Generic;

namespace FilmsCatalog.Models
{
    interface IUser
    {
        int Id { get; set; }
        string Name { get; set; }
        string SurName { get; set; }
        string FullName { get; set; }
        string registrationDate { get; }

        int UserRegisterId { get; set; }
        UserRegisterModel userRegister { get; set; }
        List<FilmModel> Films { get; set; }
    }
}
