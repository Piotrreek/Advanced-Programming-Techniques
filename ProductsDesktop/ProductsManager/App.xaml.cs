using ProductsManager.Views;

namespace ProductsManager;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}