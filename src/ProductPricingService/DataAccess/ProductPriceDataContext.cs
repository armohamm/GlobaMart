using ProductPricingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace ProductPricingService.DataAccess
{
    public class ProductPriceDataContext
    {
        IList<ProductPrice> ProductPriceCollection;

        public ProductPriceDataContext()
        {
            InitialiseData();
        }

        private void InitialiseData()
        {
            
            XDocument doc = XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + @"App_Data\ProductPrices.xml");
            var products = from p in doc.Descendants().Descendants()
                           select new ProductPrice
                           {
                               Id = p.Attribute(XName.Get("Id")).Value,
                               Name = p.Attribute(XName.Get("Name")).Value,
                               Price = p.Attribute(XName.Get("Price")).Value,
                           };
            ProductPriceCollection = products.ToList<ProductPrice>();
        }

        public IList<ProductPrice> Prices
        {
            get { return ProductPriceCollection; }
        }

    }
}