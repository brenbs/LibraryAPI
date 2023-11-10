using LibraryAPI.Data;

namespace LibraryAPI.FiltersDb
{
    public class PublisherFilterDb:PagedBaseRequest
    {
        public string? SearchValue  { get; set; }
    }
}
