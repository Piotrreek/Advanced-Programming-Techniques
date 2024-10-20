using System.Collections.ObjectModel;
using System.Windows.Input;
using AsyncAwaitBestPractices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductsManager.Models;

namespace ProductsManager.ViewModels;

public sealed class ProductsViewModel
{
    private readonly IProductService _productService;

    public ObservableCollection<Product> Products { get; private set; } = [];
    public ICommand DetailsCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand ModifyCommand { get; }

    public ProductsViewModel(IProductService productService)
    {
        _productService = productService;
        LoadProducts().SafeFireAndForget();

        DetailsCommand = new AsyncRelayCommand<int>(Details);
        DeleteCommand = new AsyncRelayCommand<int>(Delete);
        ModifyCommand = new AsyncRelayCommand<int>(Modify);
    }

    private async Task LoadProducts()
    {
        Products.Clear();

        var products = await _productService.GetProducts();

        foreach (var product in products)
        {
            Products.Add(product);
        }
    }

    private async Task Delete(int productId)
    {
        var productToRemove = Products.FirstOrDefault(p => p.Id == productId);
        if (productToRemove != null)
        {
            Products.Remove(productToRemove);
        }
    }

    private static async Task Modify(int productId)
    {
        // Assuming you have navigation set up
        await Shell.Current.GoToAsync($"//product?id={productId}");
    }

    private static async Task Details(int productId)
    {
        await Shell.Current.GoToAsync($"//product?id={productId}");
    }
}