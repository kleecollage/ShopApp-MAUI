namespace ShopApp.Views;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

    // Proteccion de rutas
    protected override async void OnAppearing()
    {
        var accessToken = Preferences.Get("accesstoken", string.Empty);
        if (string.IsNullOrEmpty(accessToken))
        {
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
        }
    }
}