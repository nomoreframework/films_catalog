﻿
namespace FilmsCatalog.Models
{
    public class PosterModel
    {
        public int Id { get; set; }
        public int FilmModelId { get; set; }
        public FilmModel Film { get; set; }
        public byte [] Poster { get; set; }
    }
}
