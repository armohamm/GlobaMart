using ProductCatalogueService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace ProductCatalogueService.DataAccess
{
    internal class ProductDataContext
    {
        IList<Product> ProductCollection;

        public ProductDataContext()
        {
            InitialiseData();
        }

        private void InitialiseData()
        {
            XDocument doc = XDocument.Load(@"C:\Users\TomCruise\Documents\Visual Studio 2015\Projects\SapientNitro\ProductCatalogueService\ProductCatalogueService\App_Data\Products.xml");
            var products = from p in doc.Descendants().Descendants()
                           select new Product
                           {
                               Id = p.Attribute(XName.Get("Id")).Value,
                               Name = p.Attribute(XName.Get("Name")).Value,
                               Type = p.Attribute(XName.Get("Type")).Value,
                           };
            ProductCollection = products.ToList<Product>();
        }

        public IList<Product> Products
        {
            get { return ProductCollection; }
        }  
    }
}