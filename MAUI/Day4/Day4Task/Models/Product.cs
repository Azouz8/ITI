namespace Day4Task.Models;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Thumbnail { get; set; } = string.Empty;
    public double Rating { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
}

public class ProductResponse
{
    public List<Product> Products { get; set; } = new();
    public int Total { get; set; }
}