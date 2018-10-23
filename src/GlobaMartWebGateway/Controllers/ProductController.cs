using GlobaMartWebGateway.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GlobaMartWebGateway.Config;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;

namespace GlobaMartWebGateway.Controllers
{
    public class ProductController : ApiController
    {
        private IServiceRegistry ServiceRegistry;
        private string CatalogueServiceUrl;
        private string PricingServiceUrl;

        public ProductController()
        {
            ServiceRegistry = ServiceRegistryProvider.GetServiceRegistry();
            CatalogueServiceUrl = ServiceRegistry.GetServiceAddress(ServiceIdentifiers.ProductCatalogue);
            PricingServiceUrl = ServiceRegistry.GetServiceAddress(ServiceIdentifiers.ProductPricing);
        }

        [Route("products/{id}")]
        public async Task<IHttpActionResult> GetProduct(string id)
        {
            try
            {
                var CatalogueServiceAddress = CatalogueServiceUrl.AppendPathSegment(String.Format("/api/products/{0}", id));
                var PricingServiceAddress = PricingServiceUrl.AppendPathSegment(String.Format("/api/price/{0}", id));

                var product = await CatalogueServiceAddress.GetJsonAsync();
                var price = await PricingServiceAddress.GetJsonAsync();
               
                if(product == null)
                {
                    return NotFound();
                }

                return Ok( new { Product = product, Price = price } );
                
            }
            catch
            {
                return InternalServerError();
            }
        }

        [Route("products")]
        public async Task<IHttpActionResult> GetProducts()
        {
            try
            {
                var CatalogueServiceAddress = CatalogueServiceUrl.AppendPathSegment("/api/products");
                var PricingServiceAddress = PricingServiceUrl.AppendPathSegment("/api/prices");

                var products = await CatalogueServiceAddress.GetJsonAsync();
                var prices = await PricingServiceAddress.GetJsonAsync();

                if (products == null)
                {
                    return NotFound();
                }

                return Ok(new { Products = products, Prices = prices });

            }
            catch
            {
                return InternalServerError();
            }
        }

        [Route("products/{type}")]
        public async Task<IHttpActionResult> GetProducts(string type)
        {
            try
            {
                var CatalogueServiceAddress = CatalogueServiceUrl.AppendPathSegment(string.Format("/api/products/{type}", type));
                var PricingServiceAddress = PricingServiceUrl.AppendPathSegment(string.Format("/api/prices/type", type));

                var products = await CatalogueServiceAddress.GetJsonAsync();
                var prices = await PricingServiceAddress.GetJsonAsync();

                if (products == null)
                {
                    return NotFound();
                }

                
                
                return Ok(new { Products = products, Prices = prices });

            }
            catch
            {
                return InternalServerError();
            }
        }

        [Route("products/types")]
        public async Task<IHttpActionResult> GetProductCategories()
        {
            try
            {
                var CatalogueServiceAddress = CatalogueServiceUrl.AppendPathSegment("/api/products/types");

                var productCategories = await CatalogueServiceAddress.GetJsonAsync();

                if (productCategories == null)
                {
                    return NotFound();
                }

                return Ok(productCategories);

            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}
