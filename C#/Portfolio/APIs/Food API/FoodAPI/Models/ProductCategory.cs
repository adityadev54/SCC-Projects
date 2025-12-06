namespace FoodAPI.Models
{
    public class ProductCategory
    {
        public string ProductId { get; set; } = null!;
        public int CategoryId { get; set; }
        public Product Product { get; set; } = null!;
        public Category Category { get; set; } = null!;
    }
}