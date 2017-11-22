using COTS.BLL.Interfaces;
using COTS.BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEB.Utils
{
    public class MovieModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMovieService>().To<MovieService>();
        }
    }
}