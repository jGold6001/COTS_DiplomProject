using COTS.BLL.Services;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using COTS.DAL.Interfaces;
using COTS.BLL.Interfaces;
using COTS.DAL.Repositories;
using System.Linq;
using COTS.BLL.DTO;

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
                Raw = 2,
                Place = 1,
                Price = 100,
                Tariff = "Simple"

            };

            ticketService.AddOrUpdate(ticketDTO);

            var ticket = ticketService.GetAll().Where(t=> t.Hall == "#1").FirstOrDefault();
            Assert.AreEqual("#1", ticket.Hall);

            if(ticketService.GetAll().Count() > 0)
            {
                foreach (var item in ticketService.GetAll())
                    ticketService.Delete(item);
            }
        }
    }
}

