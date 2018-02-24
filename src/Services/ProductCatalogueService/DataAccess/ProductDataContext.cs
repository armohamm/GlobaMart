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
        IList<Category> ProductCategories; 

        public ProductDataContext()
        {
            InitialiseData();
        }

        private void InitialiseData()
        {
            XDocument doc = XDocument.Load(@"~\App_Data\Products.xml");

            var Categories = TraverseCategories(doc.Descendants().Descendants()).ToList();

            var products = from p in doc.Descendants().Descendants()
                           select new Product
                           {
                               Id = p.Attribute(XName.Get("Id")).Value,
                               Name = p.Attribute(XName.Get("Name")).Value,
                               TypeId = p.Parent.Attribute(XName.Get("Id")).Value,
                           };
            ProductCollection = products.ToList<Product>();
        }

        private IList<Category> TraverseCategories(IEnumerable<XElement> XDoc)
        {
            if(XDoc.First().Name.Equals("Product"))
            {
                return null;
            }

            IList<Category> categories = new List<Category>();

            foreach (XElement element in XDoc)
            {
                Category category = new Category
                {
                    Id = element.Attribute(XName.Get("Id")).Value,
                    Name = element.Attribute(XName.Get("Name")).Value,
                    SubCategories = TraverseCategories(element.Descendants())
                };

                categories.Add(category);
            }

            return categories;
        }

        public IList<Product> Products
        {
            get { return ProductCollection; }
        }
        
        public IList<Category> Categories
        {
            get { return ProductCategories; }
        }
    }
}