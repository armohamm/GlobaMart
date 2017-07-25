using System.Collections.Generic;
using System.Linq;
using ProductPricingService.Models;

namespace ProductPricingService.DataAccess
{
    public class ProductPriceRepository : IProductPriceRepository
    {
        ProductPriceDataContext ProductPriceData;

        public ProductPriceRepository()
        {
            ProductPriceData = new ProductPriceDataContext();
        }

        public ProductPrice GetProductPrice(string id, string name)
        {
            var productPrice = from p in ProductPriceData.Prices
                               where p.Id.Equals(id) && p.Name.Equals(name)
                               select p;

            return productPrice.FirstOrDefault();
        }

        public IList<ProductPrice> GetProductPrices()
        {
            return ProductPriceData.Prices;
        }
    }
}