using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Routing;
using DistributedPokerHelper.Helpers;

namespace DistributedPokerHelper
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            
            HostingEnvironment.RegisterObject(new BlindTimer());
        }
    }
}
