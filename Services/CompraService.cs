using ShopApp.DataAccess;
using System.Net.Http.Json;

namespace ShopApp.Services;
public class CompraService
{
    private HttpClient client;

    public CompraService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<bool> EnviarData(IEnumerable<Compra> compras)
    {
        var uri = "http://192.168.1.160/api/compra";
        var body = new
        {
            data = compras,
        };

        var resultado = await client.PostAsJsonAsync(uri, body);

        return resultado.IsSuccessStatusCode;
    }
}
