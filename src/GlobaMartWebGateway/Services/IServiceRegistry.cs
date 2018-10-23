using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlobaMartWebGateway.Services
{
    public interface IServiceRegistry
    {
        string GetServiceAddress(string id);
    }
}