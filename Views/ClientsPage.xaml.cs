using ShopApp.DataAccess;
using ShopApp.VewModels;
namespace ShopApp.Views; public partial class ClientsPage : ContentPage { 
	public ClientsPage(ClientsViewModel viewModel) {

		InitializeComponent();
		BindingContext = viewModel;

		// AHORA LO TRABAJAMOS DESDE EL  VIEW MODEL
		//var dbContext = new ShopDbContext();
		//      foreach (var client in dbContext.Clients)
		//      {
		//          container.Children.Add(new Label { Text = client.Nombre });
		//      }
    }
}