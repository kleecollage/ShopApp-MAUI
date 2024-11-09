using ShopApp.VewModels;

namespace ShopApp.Views;

public partial class HelpSupportDetailPage : ContentPage
{
	public HelpSupportDetailPage(HelpSupportDetailViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
	}

    // MOVEMOS ESTO AL VIEWMODEL
    //public void ApplyQueryAttributes(IDictionary<string, object> query)
    //{
    //    Title = $"Cliente: {query["id"]}";
    //    var clientId = int.Parse(query["id"].ToString());
    //    (BindingContext as HelpSupportDetailViewModel).ClienteId = clientId;
    //}

}


