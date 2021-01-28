using System.Collections.Generic;
namespace FilmsCatalog.Models.PaginationModels
{
    public class MetaViewModel
    {
        public IEnumerable<FilmModel> FilmModels { get; set; }
        public PagineViewModel PaginViewModel { get; set; }
        public FilterModelView FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
