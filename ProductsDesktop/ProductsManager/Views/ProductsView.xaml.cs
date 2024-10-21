using ProductsManager.ViewModels;

namespace ProductsManager.Views;

public partial class ProductsView : ContentPage
{
    public ProductsView(ProductsViewModel productsViewModel)
    {
        InitializeComponent();

        BindingContext = productsViewModel;

        Appearing += async (_, _) => { await productsViewModel.Initialize(); };
    }
}