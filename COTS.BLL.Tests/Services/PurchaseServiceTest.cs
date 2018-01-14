using COTS.BLL.Services;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using COTS.BLL.Interfaces;
using COTS.DAL.Interfaces;
using COTS.DAL.Repositories;
using COTS.DAL.Entities;
using System.Linq;
using COTS.BLL.DTO;
using System.Diagnostics;

namespace COTS.BLL.Services.Tests
{
    [TestClass()]
    public class PurchaseServiceTest
    {
        IPurchaseService purchaseService;
        IUnitOfWork unitOfWork;

        [TestInitialize()]
        public void init()
        {
            unitOfWork = new EFUnitOfWork("CotsContext");
            purchaseService = new PurchaseService(unitOfWork);
        }

        [TestMethod()]
        public void AddOrUpdatePurchaseTest()
        {
            
        }

        [TestMethod()]
        public void GetOnePurchaseTest()
        {
            PurchaseDTO purchaseDTO = purchaseService.GetAll().FirstOrDefault();
           
        }

        [TestMethod()]
        public void DeletePurchaseTest()
        {
           
        }
    }
}

