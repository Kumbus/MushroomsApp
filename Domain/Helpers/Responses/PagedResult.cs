namespace Domain.Helpers.Responses
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }

        public PagedResult(IEnumerable<T> items, int pageSize, int totalCount, int currentPage)
        {
            int currentPageSize = items.Count();
            Items = items;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
            PageSize = currentPageSize;
            CurrentPage = currentPage;
        }
    }
}
