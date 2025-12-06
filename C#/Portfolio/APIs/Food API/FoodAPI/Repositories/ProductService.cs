using FoodAPI.Data;
using FoodAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodAPI.Repositories
{
    public class ProductService : IProductService
    {
        private readonly FoodDbContext _context;

        public ProductService(FoodDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Retrieves a paginated list of products with optional filters for category, brand, price and sorting
        public async Task<(List<Product> Items, int TotalCount)> GetProductsAsync(
            string? category, string? brand, decimal? maxPrice, string? sortBy, int page, int limit)
        {
            if (page < 1 || limit < 1)
                throw new ArgumentException("Page and limit must be positive.");

            var query = _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Nutriment)
                .Include(p => p.ProductCategories)
                    .ThenInclude(pc => pc.Category)
                .AsQueryable();

            if (!string.IsNullOrEmpty(category))
                query = query.Where(p => p.ProductCategories.Any(pc => pc.Category != null && pc.Category.Name == category));
            if (!string.IsNullOrEmpty(brand))
                query = query.Where(p => p.Brand != null && p.Brand.Name == brand);
            if (maxPrice.HasValue)
                query = query.Where(p => p.Price <= maxPrice.Value);

            // Applies sorting based on sort By parameter
            query = sortBy?.ToLower() switch
            {
                "name" => query.OrderBy(p => p.ProductName),
                "brand" => query.OrderBy(p => p.Brand != null ? p.Brand.Name : ""),
                "price" => query.OrderBy(p => p.Price),
                "date" => query.OrderBy(p => p.CreatedAt),
                _ => query.OrderBy(p => p.Id)
            };

            // Calculates total amount count for pagination
            var totalCount = await query.CountAsync();

            // Fetches paginated items
            var items = await query
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();

            return (items, totalCount);
        }

        //  Retrieves a single product by ID, including related data
        public async Task<Product?> GetProductByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;

            return await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Nutriment)
                .Include(p => p.ProductCategories)
                    .ThenInclude(pc => pc.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // Retrieves a list of all unique category names.
        public async Task<List<string>> GetCategoriesAsync()
        {
            return await _context.Categories
                .Where(c => c.Name != null)
                .Select(c => c.Name)
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();
        }

        // Retrieves a list of all unique brand names
        public async Task<List<string>> GetBrandsAsync()
        {
            return await _context.Brands
                .Where(b => b.Name != null)
                .Select(b => b.Name)
                .Distinct()
                .OrderBy(b => b)
                .ToListAsync();
        }

        // Searches products by a query string across name, brand, and categories, with pagination
        public async Task<(List<Product> Items, int TotalCount)> SearchProductsAsync(string query, int page = 1, int limit = 20)
        {
            if (string.IsNullOrEmpty(query))
                return (new List<Product>(), 0);

            if (page < 1 || limit < 1)
                throw new ArgumentException("Page and limit must be positive.");

            // Builds search quries matching ProductName, Brand, or Categories
            var searchQuery = _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Nutriment)
                .Include(p => p.ProductCategories)
                    .ThenInclude(pc => pc.Category)
                .Where(p => p.ProductName.Contains(query) ||
                            (p.Brand != null && p.Brand.Name.Contains(query)) ||
                            p.ProductCategories.Any(pc => pc.Category != null && pc.Category.Name.Contains(query)))
                .AsQueryable();

            // Calculates total count for pagination
            var totalCount = await searchQuery.CountAsync();
            var items = await searchQuery
                .OrderBy(p => p.ProductName)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();

            return (items, totalCount);
        }
    }
}