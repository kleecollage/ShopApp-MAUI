using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class InmuebleDetailPage : ContentPage
{
	public InmuebleDetailPage(InmuebleDetailViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
	}
}