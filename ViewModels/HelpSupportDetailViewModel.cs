using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopApp.DataAccess;
using ShopApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShopApp.ViewModels;

public partial class HelpSupportDetailViewModel : ViewModelGlobal, IQueryAttributable
{
    private readonly IConnectivity _connectivity;

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

    // INYECCION DE DEPENDENCIAS
    private CompraService _compraService;
    private readonly ShopOutDbContext _outDbContext;

    public HelpSupportDetailViewModel(IConnectivity connectivity, CompraService compraService, ShopOutDbContext opOutDbContext)
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
        // INYECCION DE DEPENDENCIAS
        _connectivity = connectivity;
        _connectivity.ConnectivityChanged += _connectivity_ConnectivityChanged;
        _compraService = compraService;
        _outDbContext = opOutDbContext;

    }


    [RelayCommand(CanExecute = nameof(StatusConnection))]
    private async Task EnviarCompra() //EnviarCompraCommand
    {
        // ENVIO DE DATOS A BD LOCAL
        //var resultado = await _compraService.EnviarData(Compras);
        //if (resultado)
        //{
        //    await Shell.Current.DisplayAlert("Mensaje", "Se enviaron las compras al servidor backend", "Aceptar");
        //}

        //  ENVIO DE DATOS A SQLITE
        _outDbContext.Database.EnsureCreated();

        foreach (var item in Compras)
        {
            _outDbContext.Compras.Add(new CompraItem(
                item.ClienteId,
                item.ProductId,
                item.Cantidad,
                item.ProductoPrecio
                ));
        }

        await _outDbContext.SaveChangesAsync();

        await Shell.Current.DisplayAlert("Mensaje", "Se almaceno con exito en la base de datos", "Aceptar");


    }

    private void _connectivity_ConnectivityChanged(object? sender, ConnectivityChangedEventArgs e)
    {
        EnviarCompraCommand.NotifyCanExecuteChanged();
    }

    private bool StatusConnection()
    {
        return _connectivity.NetworkAccess == NetworkAccess.Internet ? true : false;
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
