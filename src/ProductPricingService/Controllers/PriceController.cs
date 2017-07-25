using ProductPricingService.DataAccess;
using ProductPricingService.Models;
using System.Web.Http;

namespace ProductPricingService.Controllers
{
    public class PriceController : ApiController
    {
        IProductPriceRepository Repository;

        public PriceController()
        {
            Repository = RepositoryServicesProvider.GetProductPriceRepository();
        }

        [Route("api/price/{id}/{name}")]
        public IHttpActionResult Get(string id, string name)
        {
            try
            {
                ProductPrice Product = Repository.GetProductPrice(id,name);
                if (Product != null)
                {
                    return Ok(Product);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return InternalServerError();
            }
        }

        [Route("api/prices")]
        public IHttpActionResult GetPrices()
        {
            try
            {
                var ProductList = Repository.GetProductPrices();
                if (ProductList.Count > 0)
                {
                    return Ok(ProductList);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}
