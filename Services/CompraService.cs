using Microsoft.Extensions.Configuration;
using ShopApp.DataAccess;
using ShopApp.Models.Config;
using System.Net.Http.Json;

namespace ShopApp.Services;
public class CompraService
{
    private HttpClient client;
    private Settings settings;
    public CompraService(HttpClient client, IConfiguration configuration)
    {
        this.client = client;
        settings = configuration.GetRequiredSection(nameof(Settings)).Get<Settings>();
    }

    public async Task<bool> EnviarData(IEnumerable<Compra> compras)
    {
        var uri = $"{settings.UrlBase}/api/compra";
        var body = new
        {
            data = compras,
        };

        var resultado = await client.PostAsJsonAsync(uri, body);

        return resultado.IsSuccessStatusCode;
    }
}
