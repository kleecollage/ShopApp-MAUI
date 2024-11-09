
using CommunityToolkit.Mvvm.ComponentModel;
using ShopApp.DataAccess;
using System.Collections.ObjectModel;

namespace ShopApp.VewModels
{
    public partial class ClientsViewModel: ViewModelGlobal
    {
        [ObservableProperty]
        ObservableCollection<Client> clients;

        [ObservableProperty]
        Client clienteSeleccionado;

        public ClientsViewModel()
        {
            var database = new ShopDbContext();
            clients = new ObservableCollection<Client>(database.Clients);
        }
    }
}
