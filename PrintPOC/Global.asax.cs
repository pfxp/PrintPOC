using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PrintPOC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            string _path = $"{Environment.GetEnvironmentVariable("PATH")};{System.Web.Hosting.HostingEnvironment.MapPath("~/bin/x64")};{System.Web.Hosting.HostingEnvironment.MapPath("~/bin/x86")};";
            Environment.SetEnvironmentVariable("PATH", _path, EnvironmentVariableTarget.Process);
        }
    }
}
