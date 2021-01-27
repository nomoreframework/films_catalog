using FilmsCatalog.Models;
using System.Collections.Generic;

namespace FilmsCatalog.Interfaces.Model_Interfaces
{
    interface IUserRegister<R> where R : class
    {
        public List<FilmModel> Films { get; set; }
    }
}
