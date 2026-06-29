using System.Text.Json;
using System.Text.Json.Serialization;
using Day4Task.Models;

namespace Day4Task.Services;

public class ProductService
{
    private readonly HttpClient _httpClient;

    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public ProductService()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://dummyjson.com/")
        };
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        try
        {
            var response = await _httpClient.GetStringAsync("products?limit=20");
            var result = JsonSerializer.Deserialize<ProductResponse>(response, _jsonOptions);
            return result?.Products ?? new List<Product>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching products: {ex.Message}");
            return new List<Product>();
        }
    }
}