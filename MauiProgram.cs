using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShopApp.DataAccess;
using ShopApp.Services;
using ShopApp.VewModels;
using ShopApp.ViewModels;
using ShopApp.Views;
using System.Reflection;
// OBJETOS GLOBALES DE LA APLICACION
namespace ShopApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            // LLAMAMOS AL APPSETTINGS
            var assemblyInstance = Assembly.GetExecutingAssembly();
            using var stream = assemblyInstance.GetManifestResourceStream("ShopApp.appsettings.json");

            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                // CONFIGURACION DE LAS FUENTES
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                // appsettings...
                .Configuration.AddConfiguration(config);
            //INYECCION DE SERVICIOS
            builder.Services.AddSingleton<INavegacionService, NavegacionService>();
            builder.Services.AddTransient<HelpSupportViewModel>();
            builder.Services.AddTransient<HelpSupportPage>();
            builder.Services.AddTransient<HelpSupportDetailViewModel>();
            builder.Services.AddTransient<HelpSupportDetailPage>();
            builder.Services.AddTransient<ClientsViewModel>();
            builder.Services.AddTransient<ClientsPage>();
            builder.Services.AddTransient<ProductsViewModel>();
            builder.Services.AddTransient<ProductsPage>();
            builder.Services.AddTransient<ProductDetailViewModel>();
            builder.Services.AddTransient<ProductDetailPage>();
            builder.Services.AddTransient<ResumenViewModel>();
            builder.Services.AddTransient<ResumenPage>();
            builder.Services.AddSingleton(Connectivity.Current);
            builder.Services.AddSingleton<CompraService>();
            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddSingleton<IDatabaseRutaService, DatabaseRutaService>();
            builder.Services.AddDbContext<ShopOutDbContext>();
            builder.Services.AddSingleton<SecurityService>();
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<LoginPage>();
            // INSTANCIA DE LA BASE DE DATOS
            var dbContext = new ShopDbContext();
            dbContext.Database.EnsureCreated();
            dbContext.Dispose();
            // REGISTRO DE RUTAS
            Routing.RegisterRoute(nameof(ProductDetailPage), typeof(ProductDetailPage));
            Routing.RegisterRoute(nameof(HelpSupportDetailPage), typeof(HelpSupportDetailPage));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
