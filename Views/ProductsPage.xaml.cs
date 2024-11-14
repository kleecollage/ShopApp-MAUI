using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class ProductsPage : ContentPage
{
	public ProductsPage(ProductsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

		// ESTO LO TRABAJAMOS DESDE EL VM
		// var dbContext = new ShopDbContext();
		// products.ItemsSource = database.Products;
		// foreach(var product in dbContext.Products)
		// {
		//	var button = new Button { Text = product.Nombre };
		//	button.Clicked += async (s, a) =>
		//	{
		//		var uri = $"{nameof(ProductDetailPage)}?id={product.Id}";
		//		await Shell.Current.GoToAsync(uri);
		//	};
		//	container.Children.Add(button);
		//}
}