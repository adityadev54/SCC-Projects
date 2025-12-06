namespace FoodAPI.Models
{
    public class Product
    {
        public string Id { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public Brand Brand { get; set; } = null!;
        public Nutriment? Nutriment { get; set; }
        public List<ProductCategory> ProductCategories { get; set; } = new();
    }
}