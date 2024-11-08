using ShopApp.DataAccess;
using System.Collections.ObjectModel;

namespace ShopApp.Views;

public partial class HelpSupportPage : ContentPage
{
	public HelpSupportPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        var dataObj = Resources["data"] as HelpSupportData;
        dataObj.VisitasPendientes = 30;
    }
}

public class HelpSupportData : BindingUtilObject
{
    /// <summary>
    /// public int VisitasPendientes { get; set; }
    /// </summary>

    public HelpSupportData()
    {
        var database = new ShopDbContext();
        Clients = new ObservableCollection<Client>(database.Clients);
        PropertyChanged += HelpSupportData_PropertyChanged;
    }

    private async void HelpSupportData_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ClienteSeleccionado))
        {
            var uri = $"{nameof(HelpSupportDetailPage)}?id={ClienteSeleccionado.Id}";
            await Shell.Current.GoToAsync(uri);
        }
    }

    private int _visitasPendientes;
    public int VisitasPendientes
    {
        get { return _visitasPendientes; }
        set {
            if (_visitasPendientes != value)
            {
                _visitasPendientes = value;
                RaisePropertyChanged();
            }
        }
    }

    private ObservableCollection<Client> _clients;
    public ObservableCollection<Client> Clients
    {
        get { return _clients; }
        set
        {
            if (_clients != value)
            {
                _clients = value;
                RaisePropertyChanged();
            }
        }
    }

    private Client _clienteSeleccionado;
    public Client ClienteSeleccionado
    {
        get { return _clienteSeleccionado; }
        set
        {
            if (_clienteSeleccionado != value )
            {
                _clienteSeleccionado = value;
                RaisePropertyChanged();
            }
        }
    }
    


}