﻿namespace LibraryAPI.Data
{
    public class PagedBaseResponse<T>
    {
        public List<T> Data { get; set; }
        public int TotalPages { get; set; }
        public int TotalRegisters { get; set; }
    }
}
