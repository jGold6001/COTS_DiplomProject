using COTS.BLL.Services;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using COTS.DAL.Interfaces;
using COTS.BLL.Interfaces;
using COTS.DAL.Repositories;
using System.Linq;
using COTS.BLL.DTO;
using COTS.DAL.Entities;
using System.Diagnostics;

namespace COTS.BLL.Services.Tests
{
    [TestClass()]
    public class TicketServiceTest
    {
        IUnitOfWork unitOfWork;
        ITicketService ticketService;

        [TestInitialize()]
        public void init()
        {
            unitOfWork = new EFUnitOfWork("CotsContext");
            ticketService = new TicketService(unitOfWork);

        }

        [TestMethod()]
        public void AddOrUpdateTicketTest()
        {
            var seance = unitOfWork.Seances.GetAll().FirstOrDefault();

            var ticketDTO = new TicketDTO()
            {
                Id = "00000",
                SeanceId = seance.Id,
                State = 1
            };

            var placeDetailsDTO = new TicketPlaceDetailsDTO()
            {
                Id = ticketDTO.Id,
                Number = 33,
                Row = 33,
                Tariff = "xz",
                Price = 300          
            };
            ticketDTO.ticketPlaceDetailsDTO = placeDetailsDTO;

            ticketService.AddOrUpdate(ticketDTO);            
        }

        [TestMethod()]
        public void GetByPurchaseTest()
        {
            string purchaseId = "test231243";
            var ticketsDTO = ticketService.GetByPurchase(purchaseId);
            foreach (var item in ticketsDTO)
            {
                Trace.WriteLine(item.Id);
                Trace.WriteLine(item.ticketPlaceDetailsDTO.Number);
            }
        }


        [TestMethod()]
        public void GetAllTicketsTest()
        {
            var ticketsDTO = ticketService.GetAll();
            foreach (var item in ticketsDTO)
            {
                Trace.WriteLine(item.Id);
                Trace.WriteLine(item.ticketPlaceDetailsDTO.Number);
            }
        }

        [TestMethod()]
        public void GetAllBookingTicketsTest()
        {
            var ticketsDTO = ticketService.GetByState(1);
            foreach (var item in ticketsDTO)
            {
                Trace.WriteLine(item.Id);
                Trace.WriteLine(item.ticketPlaceDetailsDTO.Number);
            }
        }

        [TestMethod()]
        public void DeleteTicketTest()
        {
            ticketService.Delete("00000");
        }
    }
}

