using CommunityToolkit.Mvvm.ComponentModel;
using ShopApp.DataAccess;

namespace ShopApp.ViewModels;
public partial class ResumenViewModel : ViewModelGlobal
{
    [ObservableProperty]
    int visitas;

    [ObservableProperty]
    int clients;

    [ObservableProperty]
    decimal total;

    [ObservableProperty]
    int totalProducts;

    public ResumenViewModel(ShopOutDbContext shopOutDbContext)
    {
        var db = new ShopDbContext();

        Visitas = shopOutDbContext.Compras
             .ToList()
             .DistinctBy(s => s.ClienteId)
             .ToList()
             .Count();

        Clients = db.Clients.Count();

        Total = shopOutDbContext.Compras.ToList().Sum(s => s.Cantidad * s.Precio);
        TotalProducts = shopOutDbContext.Compras.Sum(s => s.Cantidad);
    }
}
