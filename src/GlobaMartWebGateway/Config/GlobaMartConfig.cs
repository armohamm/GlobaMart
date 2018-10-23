using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace GlobaMartWebGateway.Config
{
    public class GlobaMartConfig : ConfigurationSection
    {
        public IList<ServiceConfigElement> Services
        {
            get;
            set;
        }
    }
}