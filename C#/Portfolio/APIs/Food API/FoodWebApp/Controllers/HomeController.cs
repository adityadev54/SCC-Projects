using FoodWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;
using System.Text.Json;

namespace FoodWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _cache;

        public HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger, IMemoryCache cache)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5105/api/");
            _logger = logger;
            _cache = cache;
        }

        public async Task<IActionResult> Index(
            string[]? categories, string? brand, decimal? maxPrice, string? sortBy, string? search, int page = 1)
        {
            string endpoint = string.Empty;
            try
            {
                // Validate inputs
                if (page < 1) page = 1;
                if (string.IsNullOrEmpty(sortBy) || !new[] { "name", "brand", "price", "date" }.Contains(sortBy.ToLower()))
                    sortBy = null;

                // Build query
                var queryParams = $"?page={page}&limit=10";
                if (categories?.Any() == true)
                    queryParams += "&" + string.Join("&", categories.Select(c => $"category={Uri.EscapeDataString(c)}"));
                if (!string.IsNullOrEmpty(brand))
                    queryParams += $"&brand={Uri.EscapeDataString(brand)}";
                if (maxPrice.HasValue)
                    queryParams += $"&maxPrice={maxPrice.Value}";
                if (!string.IsNullOrEmpty(sortBy))
                    queryParams += $"&sortBy={sortBy}";

                // Use correct endpoint
                endpoint = !string.IsNullOrEmpty(search)
                    ? $"Products/search?q={Uri.EscapeDataString(search)}&page={page}&limit=10"
                    : $"Products{queryParams}";

                _logger.LogInformation("Calling FoodApi: {Endpoint}", endpoint);

                var response = await _httpClient.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<PagedResult<ProductViewModel>>(
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                result ??= new PagedResult<ProductViewModel>();

                // Cache categories and brands
                var categoriesCacheKey = "Categories";
                var brandsCacheKey = "Brands";
                List<string> allCategories = HttpContext.Session.GetObject<List<string>>(categoriesCacheKey) ?? new List<string>();
                List<string> allBrands = HttpContext.Session.GetObject<List<string>>(brandsCacheKey) ?? new List<string>();

                if (!allCategories.Any() || !allBrands.Any())
                {
                    try
                    {
                        allCategories = await _httpClient.GetFromJsonAsync<List<string>>("Products/categories") ?? new List<string>();
                        allBrands = await _httpClient.GetFromJsonAsync<List<string>>("Products/brands") ?? new List<string>();
                        HttpContext.Session.SetObject(categoriesCacheKey, allCategories);
                        HttpContext.Session.SetObject(brandsCacheKey, allBrands);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "Error fetching categories/brands");
                    }
                }

                ViewBag.Categories = allCategories;
                ViewBag.Brands = allBrands;
                ViewBag.SelectedCategories = categories?.ToList() ?? new List<string>(); // Convert to List<string>
                ViewBag.SelectedBrand = brand;
                ViewBag.MaxPrice = maxPrice;
                ViewBag.SortBy = sortBy;
                ViewBag.Search = search;

                return View(result);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error calling FoodApi: {Endpoint}", endpoint);
                ViewBag.Error = "Unable to connect to Food API. Please ensure the API is running.";
                ViewBag.Categories = new List<string>();
                ViewBag.Brands = new List<string>();
                ViewBag.SelectedCategories = categories?.ToList() ?? new List<string>();
                return View(new PagedResult<ProductViewModel>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching products");
                ViewBag.Error = "An unexpected error occurred.";
                ViewBag.Categories = new List<string>();
                ViewBag.Brands = new List<string>();
                ViewBag.SelectedCategories = categories?.ToList() ?? new List<string>();
                return View(new PagedResult<ProductViewModel>());
            }
        }

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                _logger.LogWarning("Invalid product ID");
                return BadRequest("Product ID is required.");
            }

            try
            {
                var product = await _httpClient.GetFromJsonAsync<ProductViewModel>($"Products/{id}");
                if (product == null)
                {
                    _logger.LogWarning("Product not found: {Id}", id);
                    return NotFound("Product not found.");
                }
                return View(product);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error fetching product {Id}", id);
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = "Unable to connect to Food API." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching product {Id}", id);
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = "An unexpected error occurred." });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}