using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopApp.Models.Backend.Inmueble;
using ShopApp.Services;
using ShopApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShopApp.ViewModels;
public partial class InmuebleBusquedaViewModel: ViewModelGlobal
{
    [ObservableProperty]
    ObservableCollection<InmuebleResponse> inmuebles;

    [ObservableProperty]
    private InmuebleResponse inmuebleSeleccionado;

    [ObservableProperty]
    private string searchText;

    private readonly InmuebleService _inmuebleService;

    private readonly INavegacionService _navegacionService;

    // RETURN COMMAND
    [RelayCommand]
    async Task GetBackEvent()
    {
        await _navegacionService.GoToAsync("..");
    }

    // ALTERNATIVE COMMAND METHOD
    public ICommand EjecutarBusqueda => new Command(async () =>
    {
        var inmuebleList = await _inmuebleService.GetBusquedaInmuebles(SearchText);
        Inmuebles = new ObservableCollection<InmuebleResponse>(inmuebleList);
    });

    public InmuebleBusquedaViewModel(InmuebleService inmuebleService, INavegacionService navegacionService)
    {
        _inmuebleService = inmuebleService;
        _navegacionService = navegacionService;
        PropertyChanged += InmuebleBusquedaViewModel_PropertyChanged;
    }
    
    // SELECTED ITEM
    private async void InmuebleBusquedaViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(InmuebleSeleccionado))
        {
            var uri = $"{nameof(InmuebleDetailPage)}?id={InmuebleSeleccionado.Id}";
            await _navegacionService.GoToAsync(uri);
        }
    }
}
