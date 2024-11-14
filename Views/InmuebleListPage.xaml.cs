using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class InmuebleListPage : ContentPage
{
	public InmuebleListPage(InmuebleListViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
	}
}