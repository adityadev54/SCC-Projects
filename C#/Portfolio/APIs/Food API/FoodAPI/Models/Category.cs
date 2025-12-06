namespace FoodAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<ProductCategory> ProductCategories { get; set; } = new();
    }
}