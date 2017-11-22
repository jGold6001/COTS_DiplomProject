using COTS.BLL.Infrastructure;
using COTS.WEB.Utils;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace COTS.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // inject dependencies
            NinjectModule movieModule = new MovieModule();
            NinjectModule serviceModule = new ServiceModule("CotsContext");
            var kernel = new StandardKernel(movieModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
