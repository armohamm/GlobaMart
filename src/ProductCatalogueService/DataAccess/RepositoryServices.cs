
namespace ProductCatalogueService.DataAccess
{
    class RepositoryServicesProvider
    {
        internal static IProductRepository GetProductRepository()
        {
            return new ProductRepository();
        }
    }
}