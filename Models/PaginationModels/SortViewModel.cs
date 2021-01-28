
namespace FilmsCatalog.Models.PaginationModels
{
    public enum SortState
    {
        NameAsc,    
        NameDesc,   
        YearOfIssueAsc, // по возрасту по возрастанию
        YearOfIssueDesc,    // по возрасту по убыванию
    }
    public class SortViewModel
        {
            public SortState NameSort { get; private set; } 
            public SortState YearOfIssueSort { get; private set; }  
            public SortState Current { get; private set; }     

            public SortViewModel(SortState sortOrder)
            {
                NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
                YearOfIssueSort = sortOrder == SortState.YearOfIssueAsc ? SortState.YearOfIssueDesc : SortState.YearOfIssueAsc;
                Current = sortOrder;
            }
        }
    }

