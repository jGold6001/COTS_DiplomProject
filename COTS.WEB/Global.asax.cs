using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Ninject.Modules;
using Ninject;
using Ninject.Web.Mvc;
using COTS.BLL.Infrastructure;
using COTS.WEB.Utils;
using Ninject.Web.Common;

namespace COTS.WEB
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // inject dependencies         
            NinjectModule registrations = new NinjectRegistrations();
            NinjectModule serviceModule = new ServiceModule("CotsContext");
            var kernel = new StandardKernel(registrations, serviceModule);
            var ninjectResolver = new Utils.NinjectDependencyResolver(kernel);
            DependencyResolver.SetResolver(ninjectResolver); 
        }
    }
}