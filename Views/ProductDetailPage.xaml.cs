using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class ProductDetailPage : ContentPage
{
	public ProductDetailPage(ProductDetailViewModel viewModel)
	{
		InitializeComponent();
        BindingContext=viewModel;
	}

    // AQUI OBTENEMOS LOS PARAMETROS
    // TODO ESTE METODO LO TRABAJAMOS DESDE EL VM
    //public async void ApplyQueryAttributes(IDictionary<string, object> query)
    //{
    //    var dbContext = new ShopDbContext();
    //    var id = int.Parse(query["id"].ToString());
    //    var producto = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
    //    container.Children.Add(new Label { Text = producto.Nombre });
    //    container.Children.Add(new Label { Text = producto.Descripcion });
    //    container.Children.Add(new Label { Text = producto.Precio.ToString() });
    //}
}