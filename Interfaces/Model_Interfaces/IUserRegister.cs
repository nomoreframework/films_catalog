using FilmsCatalog.Models;

namespace FilmsCatalog.Interfaces.Model_Interfaces
{
    interface IUserRegister<R> where R : UserModel
    {
        int Id { get; set; }
        R U_ser { get; set; }
    }
}
