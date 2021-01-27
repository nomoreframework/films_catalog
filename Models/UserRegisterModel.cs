using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using FilmsCatalog.Interfaces.Model_Interfaces;

namespace FilmsCatalog.Models
{
    public class UserRegisterModel : IUserRegister<UserModel>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<FilmModel> Films { get; set; }
            
            public UserRegisterModel()
        {
            Films = new List<FilmModel>();
        }
    }
}
