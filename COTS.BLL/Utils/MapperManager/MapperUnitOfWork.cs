using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.BLL.Utils.MapperManager
{
    public class MapperUnitOfWork
    {
        MovieDetailsDTOMapper movieDetailsDTOMapper;

        public MovieDetailsDTOMapper MovieDetailsDTOMapper
        {
            get
            {
                if (movieDetailsDTOMapper == null)
                    movieDetailsDTOMapper = new MovieDetailsDTOMapper();
                return movieDetailsDTOMapper;
            }
        }


    }
}