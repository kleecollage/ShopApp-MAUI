using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopApp.Services;

namespace ShopApp.VewModels;
public partial class LoginViewModel : ViewModelGlobal
{
    private readonly IConnectivity _connectivity;

    [ObservableProperty]
    private string email;

    [ObservableProperty]
    private string password;

    private readonly SecurityService _securityService;

    public LoginViewModel(IConnectivity connectivity, SecurityService securityService)
    {
        _connectivity = connectivity;
        _securityService = securityService;
        _connectivity.ConnectivityChanged += _connectivity_ConnectivityChanged;
    }

    [RelayCommand (CanExecute = nameof(StatusConnection))]
    private async Task LoginMethod()
    {
         var resultado = await _securityService.Login(Email, Password);
        if (resultado)
        {
            // REDICCION USANDO EL OBJETO SHELL
            Application.Current.MainPage = new AppShell();
        }
        else
        {
            await Shell.Current.DisplayAlert("Mensaje", "Ingreso credenciales erronreas", "Aceptar");
        }
    }
    
    private void _connectivity_ConnectivityChanged(object? sender, ConnectivityChangedEventArgs e)
    {
        LoginMethodCommand.NotifyCanExecuteChanged();
    }

    private bool StatusConnection()
    {
        return _connectivity.NetworkAccess == NetworkAccess.Internet ? true : false;
    }


}
