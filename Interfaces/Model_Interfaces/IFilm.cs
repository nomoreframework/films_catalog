using FilmsCatalog.Models;

namespace FilmsCatalog.Interfaces.Model_Interfaces
{
    interface IFilm
    {
        int Id { get; set; }
        string Name { get; set; }
        string Director { get; set; }
        string FilmDescription { get; set; }
        int YearOfIssue { get; set; }
        string PosterFilePath { get; set; }
        string dateOfCreation { get; }

        int UserRegisterModelId { get; set; }
        UserRegisterModel UserRegisterModel { get; set; }
        PosterModel Poster { get; set; }

    }
}
