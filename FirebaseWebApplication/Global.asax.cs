using FirebaseClassLibrary.Configurations;
using FirebaseClassLibrary.Entities;
using FirebaseClassLibrary.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FirebaseWebApplication
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
            FirebaseConfiguration.Load();

            FirebaseService.Instance.AttachHandler(new FirebaseServiceInterceptor((e) =>
            {
                Debug.WriteLine(e.Content.ReadAsStringAsync());
            }));
        }
    }
}
