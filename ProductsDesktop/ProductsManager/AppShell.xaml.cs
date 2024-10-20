namespace ProductsManager;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(Views.ProductView), typeof(Views.ProductView));
        Routing.RegisterRoute(nameof(Views.ProductsView), typeof(Views.ProductsView));
    }
}