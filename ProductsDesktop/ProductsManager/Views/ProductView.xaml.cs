using ProductsManager.ViewModels;

namespace ProductsManager.Views;

public partial class ProductView : ContentPage
{
    public ProductView(ProductViewModel productViewModel)
    {
        InitializeComponent();

        BindingContext = productViewModel;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        ((ProductViewModel)BindingContext).Name = null;
        ((ProductViewModel)BindingContext).Description = null;
        ((ProductViewModel)BindingContext).Price = null;
        ((ProductViewModel)BindingContext).Quantity = null;
    }
}