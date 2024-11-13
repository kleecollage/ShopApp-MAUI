using Newtonsoft.Json;
using ShopApp.Models.Backend.Login;
using System.Text;

namespace ShopApp.Services;
public class SecurityService
{
    private HttpClient client;

    public SecurityService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<bool> Login(string email, string password)
    {
        var url = "http://192.168.1.160/api/usuario/login";
        var loginRequest = new LoginRequest
        {
            Email = email,
            Password = password
        };

        var json = JsonConvert.SerializeObject(loginRequest);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync(url, content);

        if (!response.IsSuccessStatusCode) return false;

        var jsonResultado = await response.Content.ReadAsStringAsync();
        var resultado = JsonConvert.DeserializeObject<UsuarioResponse>(jsonResultado);

        Preferences.Set("accesstoken", resultado.Token);
        Preferences.Set("userid", resultado.Id);
        Preferences.Set("email", resultado.Email);
        Preferences.Set("nombre", $"{resultado.Nombre} {resultado.Apellido}");
        Preferences.Set("telefono", resultado.Telefono);
        Preferences.Set("username", resultado.UserName);

        return true;
    }
}
