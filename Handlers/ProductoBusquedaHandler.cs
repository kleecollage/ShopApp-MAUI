using ShopApp.DataAccess;
using ShopApp.Views;

namespace ShopApp.Handlers
{
    internal class ProductoBusquedaHandler: SearchHandler
    {
        ShopDbContext dbContext;

        public ProductoBusquedaHandler()
        {
            dbContext = new ShopDbContext();
        }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
                return;
            }

            var resultados = dbContext.Products
                .Where(p => p.Nombre.ToLowerInvariant()
                .Contains(newValue.ToLowerInvariant() )).ToList();

            ItemsSource = resultados;
        }

        protected async override void OnItemSelected(object item)
        {
            await Shell.Current.GoToAsync($"{nameof(ProductDetailPage)}?id={((Product)item).Id} ");
        }
    }
}
