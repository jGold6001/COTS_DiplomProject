using AutoMapper;
using COTS.BLL.DTO;
using COTS.WEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COTS.WEBAPI.Utils.MapperManager
{
    abstract public class GeneralMapper<TSource, TDestination> 
    {      

        public IMapper Mapper { get; set; }

        public abstract TDestination MapToObject(TSource value);
        public abstract IEnumerable<TDestination> MapToCollectionObjects(IEnumerable<TSource> collectValues);

    }
}