using FilmsCatalog.Models;
using System.Collections.Generic;

namespace FilmsCatalog.Interfaces.Model_Interfaces
{
    interface IUserRegister<R> where R : UserModel
    {
        public List<FilmModel> Films { get; set; }
    }
}
