using ShopApp.VewModels;

namespace ShopApp.Views;
public partial class HelpSupportPage : ContentPage
{
	public HelpSupportPage(HelpSupportViewModel viewModel)
	{
		InitializeComponent();
        // Todos los ContentPage tienen BindingContext (el vinculo entre el .cs y el .xaml)
        BindingContext = viewModel;
	}

    //private void Button_Clicked(object sender, EventArgs e)
    //{
    //    var dataObj = Resources["data"] as HelpSupportViewModel;
    //    dataObj.VisitasPendientes = 30;
    //}
}
