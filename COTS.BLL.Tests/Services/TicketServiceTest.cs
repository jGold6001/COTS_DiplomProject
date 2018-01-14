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
        public void AddOrUpdateTest()
        {
            var seance = unitOfWork.Seances.GetAll().FirstOrDefault();
            var ticketDTO = new TicketDTO()
            {
                SeanceId = seance.Id,
                Hall = "#1",
                Row = 2,
                Place = 1,
                Price = 100,
                Tariff = "Simple"
            };

            ticketService.AddOrUpdate(ticketDTO);

            var ticket = ticketService.GetAll().FirstOrDefault();
            Assert.AreEqual("#1", ticket.Hall);

            ticketService.Delete(ticket.Id);
        }

    }
}

