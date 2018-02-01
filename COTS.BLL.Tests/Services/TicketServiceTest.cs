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
        ISeanceService seanceService;
        IPlaceService placeService;

        [TestInitialize()]
        public void init()
        {
            unitOfWork = new EFUnitOfWork("CotsContext");
            ticketService = new TicketService(unitOfWork);
            seanceService = new SeanceService(unitOfWork);
            placeService = new PlaceService(unitOfWork);
        }

        [TestMethod()]
        public void AddOrUpdateTicketTest()
        {
            var seanceDTO = seanceService.GetAll().FirstOrDefault();

            var ticketDTO = new TicketDTO()
            {
                Id = "00000",
                SeanceId = seanceDTO.Id,
                State = 1,
                PlaceId = 9
            };

            ticketService.AddOrUpdate(ticketDTO);
        }

        [TestMethod()]
        public void GetTicketsByPurchaseTest()
        {
            string purchaseId = "test231243";
            var ticketsDTO = ticketService.GetByPurchase(purchaseId);
            foreach (var item in ticketsDTO)
            {
                Trace.WriteLine(item.Id);
                Trace.WriteLine($"SeanceID - {item.SeanceDTO.Id}, SeanceDate -  {item.SeanceDTO.DateAndTime.Date}");
            }
        }


        [TestMethod()]
        public void GetAllTicketsTest()
        {
            var ticketsDTO = ticketService.GetAll();
            foreach (var item in ticketsDTO)
            {
                Trace.WriteLine(item.Id);
                Trace.WriteLine($"SeanceID - {item.SeanceDTO.Id}, SeanceDate -  {item.SeanceDTO.DateAndTime.Date}");
            }
        }

        [TestMethod()]
        public void GetAllBookingTicketsTest()
        {
            var ticketsDTO = ticketService.GetByState(1);
            foreach (var item in ticketsDTO)
            {
                Trace.WriteLine(item.Id);
                Trace.WriteLine($"SeanceID - {item.SeanceDTO.Id}, SeanceDate -  {item.SeanceDTO.DateAndTime.Date}");
            }
        }

        [TestMethod()]
        public void DeleteTicketTest()
        {
            ticketService.Delete("00000");
        }

        [TestMethod()]
        public void IsPlaceInTicketTest()
        {
            var ticket = ticketService.GetAll().FirstOrDefault();
            var place = placeService.GetOne(ticket.PlaceId);

            var result = ticketService.IsPlaceInTicket(place);
            Assert.IsTrue(result);
        }
    }
}

