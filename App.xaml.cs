using ShopApp.DataAccess;
using ShopApp.Views;

namespace ShopApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
