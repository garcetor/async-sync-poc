using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AsyncSync.ClientApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ThreadPool.SetMinThreads(
                int.Parse(ConfigurationManager.AppSettings["threads:worker:min"]),
                int.Parse(ConfigurationManager.AppSettings["threads:completionPort:min"]));
            
            ThreadPool.SetMaxThreads(
                int.Parse(ConfigurationManager.AppSettings["threads:worker:max"]),
                int.Parse(ConfigurationManager.AppSettings["threads:completionPort:max"]));

            //ThreadPool.GetMinThreads(out workerThreads, out completionPortThreads);
            //ThreadPool.GetMaxThreads(out workerThreads, out completionPortThreads);
        }
    }
}
