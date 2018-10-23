using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlobaMartWebGateway.Config
{
    public class Configurations
    {
        private static GlobaMartConfig config;

        public static GlobaMartConfig Config
        {
            get
            {
                return config;
            }
        }

        public static void Register()
        {

        }
    }
}