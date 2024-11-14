using CommunityToolkit.Mvvm.ComponentModel;
using ShopApp.Models.Backend.Inmueble;
using ShopApp.Services;
using ShopApp.Views;
using System.Collections.ObjectModel;

namespace ShopApp.ViewModels;
public partial class InmuebleListViewModel : ViewModelGlobal, IQueryAttributable
{
    [ObservableProperty]
    InmuebleResponse inmuebleSeleccionado;

    private readonly INavegacionService _navegacionService;

    [ObservableProperty]
    ObservableCollection<InmuebleResponse> inmuebles;

    private readonly InmuebleService _inmuebleService;

    public InmuebleListViewModel(INavegacionService navegacionService, InmuebleService inmuebleService)
    {
        _navegacionService = navegacionService;
        _inmuebleService = inmuebleService;
        PropertyChanged += InmuebleListViewModel_PropertyChanged;
    }

    private async void InmuebleListViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if(e.PropertyName == nameof(InmuebleSeleccionado))
        {
            var uri = $"{nameof(InmuebleDetailPage)}?id={inmuebleSeleccionado.Id}";
            await _navegacionService.GoToAsync(uri);
        }
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var id = int.Parse(query["id"].ToString());
        await LoadDataAsync(id);
    }

    public async Task LoadDataAsync(int categoryId)
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;
            var listInmuebles = await _inmuebleService.GetInmueblesByCategory(categoryId);
            Inmuebles = new ObservableCollection<InmuebleResponse>(listInmuebles);
        }
        catch (Exception e)
        {
            await Application.Current.MainPage.DisplayAlert("Error", e.Message, "Aceptar");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
