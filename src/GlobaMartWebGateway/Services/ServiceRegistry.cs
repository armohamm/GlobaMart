using GlobaMartWebGateway.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlobaMartWebGateway.Services
{
    public class ServiceRegistry : IServiceRegistry
    {
        IList<ServiceConfigElement> Services;

        public ServiceRegistry()
        {
            Services = Configurations.Config.Services;
        }

        public string GetServiceAddress(string id)
        {
            return Services.First(element => element.Id.Equals(id))?.Address.Url;
        }
    }
}