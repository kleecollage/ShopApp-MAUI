using ShopApp.DataAccess;
using ShopApp.Views;

namespace ShopApp
{
    public partial class App : Application
    {
        public App(LoginPage loginPage, ShopOutDbContext context)
        {
            InitializeComponent();
            context.Database.EnsureCreated();
            // PROTECCION DE RUTAS
            var accessToken = Preferences.Get("accesstoken", string.Empty);
            if (string.IsNullOrEmpty(accessToken))
            {
                MainPage = loginPage;
            }
            else 
            {
                MainPage = new AppShell();
            }
        }
    }
}
