﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using COTS.DAL.Interfaces;
using COTS.BLL.Interfaces;
using COTS.DAL.Repositories;
using COTS.BLL.Services;
using System.Diagnostics;

namespace COTS.BLL.Services.Tests
{
    [TestClass]
    public class CityServiceTest
    {
        ICityService cityService;
        IUnitOfWork unitOfWork;

        [TestInitialize()]
        public void init()
        {
            unitOfWork = new EFUnitOfWork("CotsContext");
            cityService = new CityService(unitOfWork);
        }

        [TestMethod()]
        public void GetAllCitiesTest()
        {
            var cities = cityService.GetAll();
            foreach (var item in cities)
                Trace.WriteLine(item.Name);
        }

        [TestMethod()]
        public void GetOneCityTest()
        {
            var city = cityService.GetOne("harkov");
            Trace.WriteLine(city.Name);
        }
    }
}
