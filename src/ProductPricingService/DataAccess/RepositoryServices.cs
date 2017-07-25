
namespace ProductPricingService.DataAccess
{
    public class RepositoryServicesProvider
    {
        internal static IProductPriceRepository GetProductPriceRepository()
        {
            return new ProductPriceRepository();
        }
    }
}