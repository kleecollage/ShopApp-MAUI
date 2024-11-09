using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopApp.DataAccess;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShopApp.VewModels;

public partial class HelpSupportDetailViewModel : ViewModelGlobal, IQueryAttributable
{
    // IMPORTANTE PONER LOS PROPERTY EN LA PARTE SUPERIOR 
    [ObservableProperty]
    private ObservableCollection<Compra> compras = new ObservableCollection<Compra>();

    [ObservableProperty]
    private int clienteId;

    [ObservableProperty]
    private ObservableCollection<Product> products;

    [ObservableProperty]
    private Product productoSeleccionado;

    [ObservableProperty]
    private int cantidad;

    public HelpSupportDetailViewModel()
    {
        var database = new ShopDbContext();
        Products = new ObservableCollection<Product>(database.Products);
        AddCommand = new Command(
            () =>
            {
                if (ProductoSeleccionado == null)
                {
                    return;
                }
                var compra = new Compra(
                    ClienteId,
                    ProductoSeleccionado.Id,
                    Cantidad,
                    ProductoSeleccionado.Nombre,
                    ProductoSeleccionado.Precio,
                    ProductoSeleccionado.Precio * Cantidad
                    );
                Compras.Add(compra);
            },
            () => true
        );
    }
    public ICommand AddCommand { get; set; }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var clientId = int.Parse(query["id"].ToString());
        ClienteId = clienteId;
    }

    [RelayCommand]
    private void EliminarCompra(Compra compra)
    {
        Compras.Remove(compra);
    }
}
