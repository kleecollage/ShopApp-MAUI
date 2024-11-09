using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess;

namespace ShopApp.VewModels
{
    public partial class ProductDetailViewModel : ViewModelGlobal, IQueryAttributable
    {
        [ObservableProperty]
        string nombre;

        [ObservableProperty]
        string descripcion;

        [ObservableProperty]
        decimal precio;

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var dbContext = new ShopDbContext();
            var id = int.Parse(query["id"].ToString());
            var producto = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            // Pasamos las propiedades aqui
            Nombre = producto.Nombre;
            Descripcion = producto.Descripcion;
            Precio = producto.Precio;
            // Este codigo ya no es necesario
            // container.Children.Add(new Label { Text = producto.Nombre });
            // container.Children.Add(new Label { Text = producto.Descripcion });
            // container.Children.Add(new Label { Text = producto.Precio.ToString() });
        }
    }
}
