namespace FoodAPI.Models
{
    public class Nutriment
    {
        public string ProductId { get; set; } = null!;
        public double? EnergyKcal { get; set; }
        public double? Fat { get; set; }
        public double? Carbohydrates { get; set; }
        public double? Proteins { get; set; }
        public Product? Product { get; set; }
    }
}