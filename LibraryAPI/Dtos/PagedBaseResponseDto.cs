namespace LibraryAPI.Dtos
{
    public class PagedBaseResponseDto<T>
    {
        public PagedBaseResponseDto(int totalRegisters,int page,int totalPages, List<T> data)
        {
            TotalRegisters = totalRegisters;
            Page = page;
            TotalPages = totalPages;
            Data = data;
        }
        public int TotalRegisters { get; private set; }
        public int TotalPages { get; set; }
        public int Page { get; set; }
        public List<T> Data { get; private set; }

    }
}
