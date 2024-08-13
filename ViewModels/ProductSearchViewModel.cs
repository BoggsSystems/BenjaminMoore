using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using ProductSearchApp.Models;
using ProductSearchApp.Services;

namespace ProductSearchApp.ViewModels
{
    public class ProductSearchViewModel : INotifyPropertyChanged
    {
        private readonly ProductService _productService;
        private ObservableCollection<Product> _products;
        private ObservableCollection<Product> _shoppingList;
        private string _searchQuery;

        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public ObservableCollection<Product> ShoppingList
        {
            get => _shoppingList;
            set
            {
                _shoppingList = value;
                OnPropertyChanged(nameof(ShoppingList));
            }
        }

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                if (_searchQuery != value)
                {
                    _searchQuery = value;
                    OnPropertyChanged(nameof(SearchQuery));
                    (SearchCommand as RelayCommand)?.RaiseCanExecuteChanged();
                }
            }
        }

        public ICommand SearchCommand { get; }
        public ICommand AddToShoppingListCommand { get; }

        public ProductSearchViewModel()
        {
            _productService = new ProductService();
            Products = new ObservableCollection<Product>();
            ShoppingList = new ObservableCollection<Product>();

            SearchCommand = new RelayCommand(
                SearchProducts,
                () => !string.IsNullOrEmpty(SearchQuery)
            );
            // Assuming AddToShoppingListCommand needs a Product type parameter
            AddToShoppingListCommand = new RelayCommand<Product>(AddToShoppingList);
        }

        private void SearchProducts()
        {
            Products.Clear();
            var results = _productService.SearchProducts(SearchQuery);
            foreach (var product in results)
            {
                Products.Add(product);
            }
        }

        private void AddToShoppingList(Product product)
        {
            if (!ShoppingList.Contains(product))
            {
                ShoppingList.Add(product);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
