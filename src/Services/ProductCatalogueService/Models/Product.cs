﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ProductCatalogueService.Models
{
    public class Product
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

        public string TypeId
        {
            get;
            internal set;
        }
    }
}