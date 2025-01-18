namespace Domain.Helpers.Extensions
{
    public class QueryParameters
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Filter { get; set; }
        public string? SortBy { get; set; }
        public bool SortDescending { get; set; } = false;
    }

}
