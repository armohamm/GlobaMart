using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlobaMartWebGateway.Services
{
    public class ServiceRegistryProvider
    {
        public static IServiceRegistry GetServiceRegistry()
        {
            return new ServiceRegistry();
        }
    }
}