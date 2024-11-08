using Microsoft.EntityFrameworkCore;

namespace ShopApp.DataAccess;

public class ShopDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Client> Clients { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("ShopComputer");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category(1, "Electronicos"),
            new Category(2, "Computadoras"),
            new Category(3, "Telefonos Moviles"),
            new Category(4, "Dispositivos de Escritorio"),
            new Category(5, "Microfonos y Audio"),
            new Category(6, "Artefactos del Hogar"),
            new Category(7, "Juguetes y Juegos")
        );

        modelBuilder.Entity<Product>().HasData(
            new Product(1, "Radio Digital", "Es una radio de banda ancha", 100, 1),
            new Product(2, "Laptop Ultra", "Laptop ligera y potente", 1500, 2),
            new Product(3, "Smartphone Pro", "Teléfono móvil de última generación", 1200, 3),
            new Product(4, "Monitor 4K", "Monitor de alta resolución para escritorio", 400, 4),
            new Product(5, "Micrófono de Estudio", "Micrófono profesional para grabación", 250, 5),
            new Product(6, "Aspiradora Inteligente", "Aspiradora robótica con sensores avanzados", 300, 6),
            new Product(7, "Juguete Educativo", "Juego interactivo para niños", 50, 7),
            new Product(8, "Tablet Compacta", "Tablet portátil de 8 pulgadas", 200, 2),
            new Product(9, "Altavoz Bluetooth", "Altavoz portátil con sonido envolvente", 150, 5),
            new Product(10, "Smart TV", "Televisión inteligente con pantalla 4K", 800, 1)
        );

        modelBuilder.Entity<Client>().HasData(
            new Client(1, "Juan Pérez", "Calle 123, Ciudad Central"),
            new Client(2, "Ana Gómez", "Avenida Siempre Viva 456, Metropoli"),
            new Client(3, "Luis Ramírez", "Calle de los Pinos 789, Villa Bonita"),
            new Client(4, "María Torres", "Boulevard Principal 101, Pueblo Nuevo"),
            new Client(5, "Carlos Sánchez", "Pasaje Primavera 202, Ciudad del Sol")
        );
    }
}

public record Category(int Id, string Nombre);
public record Product(int Id, string Nombre, string Descripcion, decimal Precio, int CategoryId)
{
    public Category Category { get; set; }
}
public record Client(int Id, string Nombre, string Direccion);
