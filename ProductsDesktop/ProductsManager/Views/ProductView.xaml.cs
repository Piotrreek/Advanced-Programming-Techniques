using ProductsManager.ViewModels;

namespace ProductsManager.Views;

public partial class ProductView : ContentPage
{
    public ProductView(ProductViewModel productViewModel)
    {
        InitializeComponent();

        BindingContext = productViewModel;
        Disappearing += (_, _) => { productViewModel.Disappearing(); };
    }
}