using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class InmuebleBusquedaPage : ContentPage
{
    public InmuebleBusquedaPage(InmuebleBusquedaViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}