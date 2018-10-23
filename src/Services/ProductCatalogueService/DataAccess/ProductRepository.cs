using System.Linq;
using System.Collections.Generic;
using ProductCatalogueService.Models;
using System;

namespace ProductCatalogueService.DataAccess
{
    internal class ProductRepository : IProductRepository
    {
        ProductDataContext ProductData;

        public ProductRepository()
        {
            ProductData = new ProductDataContext();
        }

        public Product GetProduct(int Id)
        {
            var product = from p in ProductData.Products
                          where p.Id.Equals(Id)
                          select p;

            return product.FirstOrDefault(); 
        }

        public IList<Product> GetAllProducts()
        {
            return ProductData.Products;
        }

        public IList<Product> GetProducts(string type)
        {
            var products = from p in ProductData.Products
                           where p.TypeId.Equals(type)
                           select p;

            return products.ToList<Product>();
        }

        public IList<Product> GetProducts(string name, string type)
        {
            var products = from p in ProductData.Products
                           where p.Name.ToLower().Contains(name.ToLower()) && 
                                (!String.IsNullOrEmpty(type) && p.TypeId.Equals(type))
                           select p;

            return products.ToList<Product>();
        }

        public IList<Category> GetProductCategories()
        {
            return ProductData.Categories;
        }
    }
}