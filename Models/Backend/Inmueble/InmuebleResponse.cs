namespace ShopApp.Models.Backend.Inmueble;
public class InmuebleResponse
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Detalle { get; set; }
    public decimal Precio { get; set; }
    public string ImagenUrl { get; set; }
    public Guid UsuarioId { get; set; }
    public int CategoryId { get; set; }
    public bool IsTrending { get; set; }
    public bool IsBookmarkEnabled { get; set; }
    public string BookmarkUserId { get; set; }
    public string Telefono { get; set; }
}

