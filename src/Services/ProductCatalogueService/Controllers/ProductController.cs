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

        [Route("api/products/types")]
        public IHttpActionResult GetTypes()
        {
            try
            {
                return Ok(Repository.GetProductCategories());
            }
            catch
            {
                return InternalServerError();
            }
        }

        [Route("api/products/{Id}")]
        public IHttpActionResult Get(int Id)
        {
            try
            {
                return Ok(Repository.GetProduct(Id));
            }
            catch
            {
                return InternalServerError();
            }
        }

        [Route("api/products/type/{typeid}")]
        public IHttpActionResult Get(string typeid)
        {
            try
            {
                var products = Repository.GetProducts(typeid);
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

        [Route("api/products/{type}/{name}")]
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
    }
}
