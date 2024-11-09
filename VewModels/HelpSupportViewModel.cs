using CommunityToolkit.Mvvm.ComponentModel;
using ShopApp.DataAccess;
using ShopApp.Services;
using ShopApp.Views;
using System.Collections.ObjectModel;

namespace ShopApp.VewModels;
public partial class HelpSupportViewModel : ViewModelGlobal
{

    // ESTA ANOTACION GENERA AUTOMATICAMENTE EL GET Y EL SET
    [ObservableProperty]
    private int visitasPendientes;
    //public int VisitasPendientes
    //{
    //    get { return _visitasPendientes; }
    //    set
    //    {
    //        if (_visitasPendientes != value)
    //        {
    //            _visitasPendientes = value;
    //            OnPropertyChanged();
    //        }
    //    }
    //}  TODA ESTA IMPLEMENTACION SE HACE AUTOMATICAMENTE CON LA ANOTACION

    [ObservableProperty]
    private ObservableCollection<Client> clients;

    [ObservableProperty]
    private Client clienteSeleccionado;

    // Inyeccion de dependencias
    private readonly INavegacionService _navegacionService;
    public HelpSupportViewModel(INavegacionService navegacionService)
    {
        var database = new ShopDbContext();
        Clients = new ObservableCollection<Client>(database.Clients);
        PropertyChanged += HelpSupportData_PropertyChanged;
        _navegacionService = navegacionService;
    }

    private async void HelpSupportData_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ClienteSeleccionado))
        {
            var uri = $"{nameof(HelpSupportDetailPage)}?id={ClienteSeleccionado.Id}";
            await _navegacionService.GoToAsync(uri);
        }
    }

}

    

