namespace LibraryAPI.Data
{
    public class PagedBaseRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string OrderByPorperty { get; set; }

        public PagedBaseRequest()
        {
            Page = 1;
            PageSize = 10;
            OrderByPorperty = "Id";
        }
    }
    
}
