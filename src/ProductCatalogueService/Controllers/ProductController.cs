using ProductCatalogueService.DataAccess;
using ProductCatalogueService.Models;
using System.Web.Http;

namespace ProductCatalogueService.Controllers
{
    public class ProductsController : ApiController
    {
        IProductRepository Repository;

        public ProductsController()
        {
            Repository = RepositoryServicesProvider.GetProductRepository();
        }

        [Route("api/products")]
        public IHttpActionResult Get()
        {
            try
            {
                var products = Repository.GetAllProducts();
                if(products.Count > 0)
                {
                    return Ok(products);
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

        [Route("api/products/{name}/{type}")]
        public IHttpActionResult Get(string name, string type)
        {
            try
            {
                var products = Repository.GetProducts(name, type);
                if (products.Count > 0)
                {
                    return Ok(products);
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

        [Route("api/products/types")]
        public IHttpActionResult GetTypes()
        {
            try
            {
                return Ok(Repository.GetProductsType());
            }
            catch
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Post(Product p)
        {
            try
            {
                return Ok(Repository.AddProduct(p));
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}
