using FilmsCatalog.Models;

namespace FilmsCatalog.Interfaces.Model_Interfaces
{
    interface IUserRegister
    {
        int Id { get; set; }
        UserModel U_ser { get; set; }
    }
}
