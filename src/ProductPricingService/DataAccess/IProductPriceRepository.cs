using ProductPricingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPricingService.DataAccess
{
    public interface IProductPriceRepository
    {
        IList<ProductPrice> GetProductPrices();
        ProductPrice GetProductPrice(string id, string name);
    }
}
