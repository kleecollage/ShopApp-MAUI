namespace ShopApp.Services;
public class NavegacionService : INavegacionService
{
    public Task GoToAsync(string uri)
    {
        return Shell.Current.GoToAsync(uri);
    }

    public Task GoToAsync(string uri, IDictionary<string, object> parameters)
    {
        return Shell.Current.GoToAsync(uri, parameters);
    }
}

