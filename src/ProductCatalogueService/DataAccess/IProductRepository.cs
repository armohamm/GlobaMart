﻿using ProductCatalogueService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogueService.DataAccess
{
    interface IProductRepository
    {
        IList<Product> GetProducts(string name, string type);
        IList<Product> GetProducts(string type);
        bool AddProduct(Product product);
        IList<Product> GetAllProducts();
        IList<string> GetProductsType();
    }
}
