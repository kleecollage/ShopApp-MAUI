using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopApp.DataAccess;
using ShopApp.Services;
using ShopApp.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ShopApp.VewModels
{
    public partial class ProductsViewModel: ViewModelGlobal
    {
        private readonly INavegacionService navegacionService;

        [ObservableProperty]
        ObservableCollection<Product> products;

        [ObservableProperty]
        Product productoSeleccionado;

        [ObservableProperty]
        bool isRefreshing;

        public ProductsViewModel(INavegacionService navegacionService)
        {
            this.navegacionService = navegacionService;
            CargarListaProductos();
            PropertyChanged += ProductsViewModel_PropertyChanged;
        }

        // Con esta anotacion, El metodo se genera con Command al final del nombre
        // (RefreshCommand)
        [RelayCommand]
        private async Task Refresh() 
        {
            CargarListaProductos();
            await Task.Delay(2000);
            // lo correcto debe ser invocar la llamada a un rest service
            // la data se almacena en la bd
            // se vuelve a consultar la data de la db local
            IsRefreshing = false;
        }

        private async void ProductsViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(ProductoSeleccionado))
            {
                var uri = $"{nameof(ProductDetailPage)}?id={ProductoSeleccionado.Id}";
                await navegacionService.GoToAsync(uri);
            }
        }

        private void CargarListaProductos()
        {
            var database = new ShopDbContext();
            Products = new ObservableCollection<Product>(database.Products);
            database.Dispose();
        }
    }
}