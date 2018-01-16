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
        ITicketService ticketService;
        ISeanceService seanceService;
        IUnitOfWork unitOfWork;

        [TestInitialize()]
        public void init()
        {
            unitOfWork = new EFUnitOfWork("CotsContext");
            purchaseService = new PurchaseService(unitOfWork);
            ticketService = new TicketService(unitOfWork);
            seanceService = new SeanceService(unitOfWork);
        }

        [TestMethod()]
        public void AddOrUpdatePurchaseTest()
        {

            var purchaseDTO = new PurchaseDTO()
            {
                Id = "001",
            };

            var clientDetailsDTO = new PurchaseClientDetailsDTO()
            {
                Id = purchaseDTO.Id,
                Email = "hello@milo.net",
                FullName = "Hellovik Helovik",
                Phone = 380567779988
            };

            purchaseDTO.PurchaseClientDetailsDTO = clientDetailsDTO;
            purchaseService.AddOrUpdate(purchaseDTO);

        
            var seanceDTO = seanceService.GetAll().FirstOrDefault();

            var ticketDTO = new TicketDTO()
            {
                Id = "00001",
                SeanceDTO = seanceDTO,
                State = 1,
                PurchaseId = purchaseDTO.Id
            };

            var placeDetailsDTO = new TicketPlaceDetailsDTO()
            {
                Id = ticketDTO.Id,
                Number = 44,
                Row = 44,
                Tariff = "xz2",
                Price = 400
            };

            ticketDTO.TicketPlaceDetailsDTO = placeDetailsDTO;
            ticketService.AddOrUpdate(ticketDTO);

        }

        [TestMethod()]
        public void GetOnePurchaseTest()
        {
            var purchseDTO = purchaseService.GetOne("001");
            Trace.WriteLine($"id= {purchseDTO.Id}, clientName = {purchseDTO.PurchaseClientDetailsDTO.FullName}");
            Trace.WriteLine($"\n\ntickets:");
            foreach (var item in purchseDTO.TicketsDTOs)
            {
                Trace.WriteLine(item.Id);
                Trace.WriteLine(item.TicketPlaceDetailsDTO.Number);
                Trace.WriteLine($"SeanceID - {item.SeanceDTO.Id}, SeanceDate -  {item.SeanceDTO.DateAndTime.Date}");
            }
        }

        [TestMethod()]
        public void GetAllPurchaseTest()
        {
            var purchasesDTOs = purchaseService.GetAll();
            foreach (var item in purchasesDTOs)
            {
                Trace.WriteLine($"id= {item.Id}, clientName = {item.PurchaseClientDetailsDTO.FullName}");
                foreach (var ticket in item.TicketsDTOs)
                {
                    Trace.WriteLine(ticket.Id);
                    Trace.WriteLine(ticket.TicketPlaceDetailsDTO.Number);
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

