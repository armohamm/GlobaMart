using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductCatalogueService.Models
{
    public class Category
    {
        public string Id
        {
            get;
            internal set;
        }

        public string Name
        {
            get;
            internal set;
        }

        public IList<Category> SubCategories
        {
            get;
            internal set;
        }
    }
}