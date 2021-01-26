using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmsCatalog.Interfaces.Model_Interfaces;

namespace FilmsCatalog.Models
{
    public class FilmModel : IFilm
    {
        int IFilm.Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IFilm.Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IFilm.Director { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IFilm.FilmDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int IFilm.YearOfIssue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IFilm.PosterFilePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        string IFilm.dateOfCreation => throw new NotImplementedException();

        int IFilm.UserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        UserModel IFilm.U_ser { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        PosterModel IFilm.Poster { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
