using Microsoft.Extensions.Logging;
using ProductsManager.Models;
using ProductsManager.ViewModels;
using ProductsManager.Views;

namespace ProductsManager;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddScoped<App>();

        builder.Services.AddScoped<ProductView>();
        builder.Services.AddScoped<ProductsView>();

        builder.Services.AddScoped<ProductViewModel>();
        builder.Services.AddScoped<ProductsViewModel>();

        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped(_ => new HttpClient());

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}