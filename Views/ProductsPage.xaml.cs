using ShopApp.DataAccess;

namespace ShopApp.Views;

public partial class ProductsPage : ContentPage
{
	public ProductsPage()
	{
		InitializeComponent();

		var database = new ShopDbContext();
		products.ItemsSource = database.Products;

		//var dbContext = new ShopDbContext();

		//foreach(var product in dbContext.Products)
		//{
		//	var button = new Button { Text = product.Nombre };
		//	button.Clicked += async (s, a) =>
		//	{
		//		var uri = $"{nameof(ProductDetailPage)}?id={product.Id}";
		//		await Shell.Current.GoToAsync(uri);
		//	};

		//	container.Children.Add(button);
		//}
	}
}