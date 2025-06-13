
namespace BooksApi.Data.Models
{
    public class FilterVM
    {
        public int PageSize { get; set; } = 20;
        public int PageNumber { get; set; } = 1;
        public string SearchFilter { get; set; }
        public string SortDirection { get; set; } = "asc";
        public string SortBy { get; set; } = "Name";
    }
}
