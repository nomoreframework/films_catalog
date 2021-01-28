using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using FilmsCatalog.Models;

namespace FilmsCatalog.Models.PaginationModels
{
    public class FilterModelView
    {
        public FilterModelView(List<FilmModel> films, int? film, string name)
        {
            films.Insert(0, new FilmModel { Name = "Все", Id = 0 });
            Films = new SelectList(films, "Id", "Name", film);
            SelectedCompany = film;
            SelectedName = name;
        }
        public SelectList Films { get; private set; } 
        public int? SelectedCompany { get; private set; }
        public string SelectedName { get; private set; } 
    }
}