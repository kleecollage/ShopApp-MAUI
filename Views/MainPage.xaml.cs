using Microsoft.Maui.Controls.Shapes;
using ShopApp.DataAccess;

namespace ShopApp.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        var dbContext = new ShopDbContext();
        category.Text = dbContext.Categories.Count().ToString();
        client.Text = dbContext.Clients.Count().ToString();
        product.Text = dbContext.Products.Count().ToString();
    }
    // Metodo de animacion simple
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        // await DisplayAlert("Mensaje de Vaxi", "Hola VaxiDrez", "Cancelar");
        (sender as Rectangle)?.ScaleTo(2);
        (sender as Rectangle)?.TranslateTo(200, 200);
    }
}
