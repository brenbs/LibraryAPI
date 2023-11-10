using LibraryAPI.Data;

namespace LibraryAPI.FiltersDb
{
    public class FilterDb:PagedBaseRequest
    {
        public string? SearchValue  { get; set; }
    }
}
