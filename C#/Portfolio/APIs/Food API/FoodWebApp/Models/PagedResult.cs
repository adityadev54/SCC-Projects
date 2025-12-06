namespace FoodWebApp.Models
{
    public class PagedResult<T>
    {
        public List<T> Data { get; set; } = new();
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)Limit);
    }
}
