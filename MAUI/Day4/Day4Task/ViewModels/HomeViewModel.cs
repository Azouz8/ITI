using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Day4Task.Models;
using Day4Task.Services;

namespace Day4Task.ViewModels;

public class HomeViewModel : INotifyPropertyChanged
{
    private readonly ProductService _productService;

    private ObservableCollection<Product> _products = new();
    private bool _isLoading;
    private string _errorMessage = string.Empty;

    public ObservableCollection<Product> Products
    {
        get => _products;
        set { _products = value; OnPropertyChanged(); }
    }

    public bool IsLoading
    {
        get => _isLoading;
        set { _isLoading = value; OnPropertyChanged(); }
    }

    public string ErrorMessage
    {
        get => _errorMessage;
        set { _errorMessage = value; OnPropertyChanged(); }
    }

    public ICommand LoadProductsCommand { get; }

    public HomeViewModel()
    {
        _productService = new ProductService();
        LoadProductsCommand = new Command(async () => await LoadProductsAsync());

        LoadProductsCommand.Execute(null);
    }

    private async Task LoadProductsAsync()
    {
        IsLoading = true;
        ErrorMessage = string.Empty;

        var products = await _productService.GetProductsAsync();

        if (products.Count == 0)
        {
            ErrorMessage = "No products found or failed to load.";
        }
        else
        {
            Products = new ObservableCollection<Product>(products);
        }

        IsLoading = false;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string name = "")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}