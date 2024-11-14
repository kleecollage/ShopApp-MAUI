using CommunityToolkit.Mvvm.Input;
using ShopApp.Services;
using ShopApp.Views;

namespace ShopApp.ViewModels;
public partial class SettingsViewModel : ViewModelGlobal
{
    private readonly INavegacionService _navegacionService;

    [RelayCommand]
    async Task SalirSesion()
    {
        Preferences.Set("accesstoken", string.Empty);
        // AboutPage contiene la proteccion de rutas
        var uri = $"//{nameof(AboutPage)}";
        await _navegacionService.GoToAsync(uri);
    }

    public SettingsViewModel(INavegacionService navegacionService)
    {
        _navegacionService = navegacionService;
    }
}

