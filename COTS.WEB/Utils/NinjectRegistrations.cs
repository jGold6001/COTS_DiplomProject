using COTS.BLL.Interfaces;
using COTS.BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEB.Utils
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IMovieService>().To<MovieService>();
            Bind<ICityService>().To<CityService>();
            Bind<ICinemaService>().To<CinemaService>();
            Bind<ISeanceService>().To<SeanceService>();
            Bind<ITicketService>().To<TicketService>();
            Bind<IPurchaseService>().To<PurchaseService>();
        }
    }
}