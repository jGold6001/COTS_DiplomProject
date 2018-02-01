using System;
using System.Web;
using System.Web.Http;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.WebApi;
using COTS.WEBAPI.App_Start;
using Ninject.Web.Common.WebHost;
using COTS.BLL.Interfaces;
using COTS.BLL.Services;
using COTS.BLL.Utils;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace COTS.WEBAPI.App_Start
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel(new ServiceModule("CotsContext"));
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                

                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IMovieService>().To<MovieService>();
            kernel.Bind<ICityService>().To<CityService>();
            kernel.Bind<ICinemaService>().To<CinemaService>();
            kernel.Bind<ISeanceService>().To<SeanceService>();
            kernel.Bind<ITicketService>().To<TicketService>();
            kernel.Bind<IPurchaseService>().To<PurchaseService>();
            kernel.Bind<IPlaceService>().To<PlaceService>();
            kernel.Bind<ITariffService>().To<TariffService>();
            kernel.Bind<ITechnologyService>().To<TechnologyService>();
            
        }
    }
}