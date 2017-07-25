using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductPricingService.Models
{
    public class ProductPrice
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

        public string Price
        {
            get;
            internal set;
        }
    }
}