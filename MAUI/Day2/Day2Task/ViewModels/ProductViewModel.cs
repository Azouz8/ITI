using Day2Task.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Day2Task.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        private string _category = string.Empty;
        public string Category
        {
            get => _category;
            set { _category = value; OnPropertyChanged(); }
        }

        private string _priceText = string.Empty;
        public string PriceText
        {
            get => _priceText;
            set { _priceText = value; OnPropertyChanged(); }
        }

        private string _description = string.Empty;
        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(); }
        }

        private string _stockText = string.Empty;
        public string StockText
        {
            get => _stockText;
            set { _stockText = value; OnPropertyChanged(); }
        }


        private Product? _submittedProduct;
        public Product? SubmittedProduct
        {
            get => _submittedProduct;
            set
            {
                _submittedProduct = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasSubmitted));
            }
        }

        public bool HasSubmitted => SubmittedProduct != null;


        private string _errorMessage = string.Empty;
        public string ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);


        public ICommand SubmitCommand { get; }

        public ProductViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }

        private void OnSubmit()
        {
            ErrorMessage = string.Empty;
            SubmittedProduct = null;
            OnPropertyChanged(nameof(HasError));

            if (string.IsNullOrWhiteSpace(Name))
            {
                ErrorMessage = "Product name is required.";
                OnPropertyChanged(nameof(HasError));
                return;
            }

            if (string.IsNullOrWhiteSpace(Category))
            {
                ErrorMessage = "Category is required.";
                OnPropertyChanged(nameof(HasError));
                return;
            }

            if (!decimal.TryParse(PriceText, out decimal price) || price < 0)
            {
                ErrorMessage = "Please enter a valid price.";
                OnPropertyChanged(nameof(HasError));
                return;
            }

            if (!int.TryParse(StockText, out int stock) || stock < 0)
            {
                ErrorMessage = "Please enter a valid stock quantity.";
                OnPropertyChanged(nameof(HasError));
                return;
            }

            SubmittedProduct = new Product
            {
                Name = Name.Trim(),
                Category = Category.Trim(),
                Price = price,
                Description = Description.Trim(),
                Stock = stock
            };
        }
    }
}

