using FoodAPI.Models;

namespace FoodAPI.Repositories
{
    public interface IProductService
    {
        Task<(List<Product> Items, int TotalCount)> GetProductsAsync(
            string? category, string? brand, decimal? maxPrice, string? sortBy, int page, int limit);
        Task<Product?> GetProductByIdAsync(string id);
        Task<List<string>> GetCategoriesAsync();
        Task<List<string>> GetBrandsAsync();
        Task<(List<Product> Items, int TotalCount)> SearchProductsAsync(string query, int page = 1, int limit = 20);
    }
}