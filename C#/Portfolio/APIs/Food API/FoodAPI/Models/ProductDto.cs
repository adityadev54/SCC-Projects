namespace FoodAPI.Models
{
    public class ProductDto
    {
        public string Id { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public NutrimentDto? Nutriment { get; set; }
        public List<string> Categories { get; set; } = new();
    }
}
