using MonkeyCache.FileStore;
using ProductsManager.Views;

namespace ProductsManager;

public partial class App : Application
{
    public App()
    {
        Barrel.ApplicationId = "ProductsDesktop";
        
        InitializeComponent();
        
        MainPage = new AppShell();
    }
}