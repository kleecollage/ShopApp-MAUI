
using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class ResumenPage : ContentPage
{
    public ResumenPage(ResumenViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}