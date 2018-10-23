using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace GlobaMartWebGateway.Config
{
    public class Address
    {
        public string Url
        {
            get;
            set;
        }
    }

    public class ServiceConfigElement : ConfigurationElement
    {
        public string Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public Address Address
        {
            get;
            set;
        }
    }
}