using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmsCatalog.Interfaces.Model_Interfaces;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmsCatalog.Models
{
    public class FilmModel : IFilm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Director { get ; set ; }
        public string FilmDescription { get ; set ; }
        public int YearOfIssue { get ; set; }
        public string PosterFilePath { get; set; }

        public string dateOfCreation { get; private set;}
        [NotMapped]
        public IFormFile PosterView { get; set; }

        public int UserRegisterModelId { get; set; }
        public UserRegisterModel U_ser { get; set; }
        public PosterModel Poster { get; set; }
            public FilmModel()
        {
            dateOfCreation = DateTime.Now.ToShortDateString();
        }
    }
}
