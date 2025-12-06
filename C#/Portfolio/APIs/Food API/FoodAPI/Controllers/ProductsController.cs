using FoodAPI.Models;
using FoodAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService service, ILogger<ProductsController> logger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // Retrieves a paginated list of products with optional filters for category, brand, price and sorting
        [HttpGet]
        public async Task<IActionResult> GetProducts(
            [FromQuery] string? category,
            [FromQuery] string? brand,
            [FromQuery] decimal? maxPrice,
            [FromQuery] string? sortBy,
            [FromQuery] int page = 1,
            [FromQuery] int limit = 20)
        {
            if (page < 1 || limit < 1)
            {
                _logger.LogWarning("Invalid pagination: page={Page}, limit={Limit}", page, limit);
                return BadRequest("Page and limit must be positive.");
            }

            if (!string.IsNullOrEmpty(sortBy) && !new[] { "name", "brand", "price", "date" }.Contains(sortBy.ToLower()))
            {
                _logger.LogWarning("Invalid sortBy: {SortBy}", sortBy);
                return BadRequest("SortBy must be 'name', 'brand', 'price', or 'date'.");
            }

            try
            {
                // Fetches products with filters and pagination
                var (items, totalCount) = await _service.GetProductsAsync(category, brand, maxPrice, sortBy, page, limit);
                _logger.LogInformation("Fetched {Count} products for page {Page}, category={Category}, brand={Brand}", items.Count, page, category, brand);

                // This Maps products to DTOs and include pagination metadata
                return Ok(new
                {
                    Data = items.Select(p => new ProductDto
                    {
                        Id = p.Id,
                        ProductName = p.ProductName,
                        Brand = p.Brand?.Name ?? "Unknown",
                        Price = p.Price,
                        CreatedAt = p.CreatedAt,
                        Nutriment = p.Nutriment != null ? new NutrimentDto
                        {
                            EnergyKcal = p.Nutriment.EnergyKcal,
                            Fat = p.Nutriment.Fat,
                            Carbohydrates = p.Nutriment.Carbohydrates,
                            Proteins = p.Nutriment.Proteins
                        } : null,
                        Categories = p.ProductCategories?.Select(pc => pc.Category?.Name).Where(c => c != null).ToList() ?? new List<string>()
                    }),
                    Meta = new
                    {
                        TotalCount = totalCount,
                        Page = page,
                        Limit = limit,
                        TotalPages = (int)Math.Ceiling(totalCount / (double)limit)
                    }
                });
            }
            catch (Exception ex)
            {
                // Logs and returns server error
                _logger.LogError(ex, "Error fetching products: category={Category}, brand={Brand}, maxPrice={MaxPrice}", category, brand, maxPrice);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Retrieves a single product by its ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            // Validates the product ID
            if (string.IsNullOrEmpty(id))
            {
                _logger.LogWarning("Invalid product ID");
                return BadRequest("Product ID is required.");
            }

            try
            {
                // Fetches product by ID
                var product = await _service.GetProductByIdAsync(id);
                if (product == null)
                {
                    _logger.LogWarning("Product not found: {Id}", id);
                    return NotFound("Product not found.");
                }

                _logger.LogInformation("Fetched product: {Id}", id);

                // Maps product to DTO
                return Ok(new ProductDto
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    Brand = product.Brand?.Name ?? "Unknown",
                    Price = product.Price,
                    CreatedAt = product.CreatedAt,
                    Nutriment = product.Nutriment != null ? new NutrimentDto
                    {
                        EnergyKcal = product.Nutriment.EnergyKcal,
                        Fat = product.Nutriment.Fat,
                        Carbohydrates = product.Nutriment.Carbohydrates,
                        Proteins = product.Nutriment.Proteins
                    } : null,
                    Categories = product.ProductCategories?.Select(pc => pc.Category?.Name).Where(c => c != null).ToList() ?? new List<string>()
                });
            }
            catch (Exception ex)
            {
                // Loggs and return server error
                _logger.LogError(ex, "Error fetching product: {Id}", id);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Retrieves a list of all available categories
        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                // Fetches all categories
                var categories = await _service.GetCategoriesAsync();
                _logger.LogInformation("Fetched {Count} categories", categories.Count);
                return Ok(categories);
            }
            catch (Exception ex)
            {
                // Logs and returns server error
                _logger.LogError(ex, "Error fetching categories");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Retrieves a list of all available brands
        [HttpGet("brands")]
        public async Task<IActionResult> GetBrands()
        {
            try
            {
                // Fetches all brands
                var brands = await _service.GetBrandsAsync();
                _logger.LogInformation("Fetched {Count} brands", brands.Count);
                return Ok(brands);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching brands");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Searches products by a query string with pagination
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? q, [FromQuery] int page = 1, [FromQuery] int limit = 20)
        {
            if (string.IsNullOrEmpty(q))
            {
                _logger.LogWarning("Search query missing: page={Page}, limit={Limit}", page, limit);
                return BadRequest("Search query is required.");
            }

            if (page < 1 || limit < 1)
            {
                _logger.LogWarning("Invalid pagination: page={Page}, limit={Limit}", page, limit);
                return BadRequest("Page and limit must be positive.");
            }

            try
            {
                var (items, totalCount) = await _service.SearchProductsAsync(q, page, limit);
                _logger.LogInformation("Search returned {Count} products for query: {Query}, page={Page}", items.Count, q, page);

                return Ok(new
                {
                    Data = items.Select(p => new ProductDto
                    {
                        Id = p.Id,
                        ProductName = p.ProductName,
                        Brand = p.Brand?.Name ?? "Unknown",
                        Price = p.Price,
                        CreatedAt = p.CreatedAt,
                        Nutriment = p.Nutriment != null ? new NutrimentDto
                        {
                            EnergyKcal = p.Nutriment.EnergyKcal,
                            Fat = p.Nutriment.Fat,
                            Carbohydrates = p.Nutriment.Carbohydrates,
                            Proteins = p.Nutriment.Proteins
                        } : null,
                        Categories = p.ProductCategories?.Select(pc => pc.Category?.Name).Where(c => c != null).ToList() ?? new List<string>()
                    }),
                    Meta = new
                    {
                        TotalCount = totalCount,
                        Page = page,
                        Limit = limit,
                        TotalPages = (int)Math.Ceiling(totalCount / (double)limit)
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching products: query={Query}, page={Page}, limit={Limit}", q, page, limit);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}