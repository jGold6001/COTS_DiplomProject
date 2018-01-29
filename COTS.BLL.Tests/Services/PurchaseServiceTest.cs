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
using System.Collections.Generic;

namespace COTS.BLL.Services.Tests
{
    [TestClass()]
    public class PurchaseServiceTest
    {
        IPurchaseService purchaseService;
        ITicketService ticketService;
        ICustomerService customerService;
        ISeanceService seanceService;
        ITariffService tariffService;
        IUnitOfWork unitOfWork;

        [TestInitialize()]
        public void init()
        {
            unitOfWork = new EFUnitOfWork("CotsContext");
            purchaseService = new PurchaseService(unitOfWork);
            customerService = new CustomerService(unitOfWork);
            ticketService = new TicketService(unitOfWork);
            seanceService = new SeanceService(unitOfWork);
            tariffService = new TariffService(unitOfWork);
        }

        [TestMethod()]
        public void AddOrUpdatePurchaseTest()
        {
            var seanceDTO = seanceService.GetAll().FirstOrDefault();
            var tariffDTO = tariffService.GetOne(unitOfWork.Tariffs.FindBy(t => t.Name == "day_holiday_green").FirstOrDefault().Id);

            var purchaseDTO = new PurchaseDTO()
            {
                Id = "001",
                Sum = tariffDTO.Price * 2
            };

            var customerDTO = new CustomerDTO()
            {
                Id = purchaseDTO.Id,
                Email = "hello@milo.net",
                FullName = "Hellovik Helovik",
                Phone = 380567779988
            };


            
            var ticketDTO = new TicketDTO()
            {
                Id = "00001",
                SeanceId = seanceDTO.Id,
                PlaceId = 8,
                State = 1,
                PurchaseId = purchaseDTO.Id,
                TariffId = tariffDTO.Id
            };

            purchaseDTO.CustomerDTO = customerDTO;          
            purchaseDTO.TicketsDTOs = new List<TicketDTO>(){ ticketDTO };
            purchaseService.AddOrUpdate(purchaseDTO);

        }

        [TestMethod()]
        public void GetOnePurchaseTest()
        {
            var purchseDTO = purchaseService.GetOne("001");
            Trace.WriteLine($"id= {purchseDTO.Id}, clientName = {purchseDTO.CustomerDTO.FullName}");
            Trace.WriteLine($"\n\ntickets:");
            foreach (var item in purchseDTO.TicketsDTOs)
            {
                Trace.WriteLine(item.Id);
                Trace.WriteLine($"SeanceID - {item.SeanceDTO.Id}, SeanceDate -  {item.SeanceDTO.DateAndTime.Date}, TarriffName -  ");
            }
        }

        [TestMethod()]
        public void GetAllPurchaseTest()
        {
            var purchasesDTOs = purchaseService.GetAll();
            foreach (var item in purchasesDTOs)
            {
                Trace.WriteLine($"id= {item.Id}, clientName = {item.CustomerDTO.FullName}");
                foreach (var ticket in item.TicketsDTOs)
                {
                    Trace.WriteLine(ticket.Id);
                    Trace.WriteLine($"SeanceID - {ticket.SeanceDTO.Id}, SeanceDate -  {ticket.SeanceDTO.DateAndTime.Date}");
                }
            }              

        }

        [TestMethod()]
        public void DeletePurchaseTest()
        {
            purchaseService.Delete("001");
        }
    }
}

