namespace ShopApp.Services;
public interface INavegacionService
{
    Task GoToAsync(string uri);
    Task GoToAsync(string uri, IDictionary<string, object> parameters);
}

