using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using COTS.DAL.Interfaces;
using COTS.DAL.Repositories;
using COTS.BLL.DTO;
using System.Linq;
using COTS.BLL.Interfaces;
using COTS.BLL.Services;
using System.Diagnostics;
using COTS.BLL.Managers.PlaceManager;

namespace COTS.BLL.Managers
{
    [TestClass()]
    public class PlaceDTOManagerTest
    {
        IUnitOfWork unitOfWork;
        IPlaceService placeService;
        ISeanceService seanceService;
        ITicketService ticketService;


        [TestInitialize]
        public void Init()
        {
            unitOfWork = new EFUnitOfWork("CotsContext");
            seanceService = new SeanceService(unitOfWork);
            placeService = new PlaceService(unitOfWork);
            ticketService = new TicketService(unitOfWork);
        }

        [TestMethod]
        public void AssignIsBusyTo_isTrue_Test()
        {
           
           var ticketDTO = this.CreateAndGetTicketDTO();

            var placeDTO = placeService.GetOne(ticketDTO.PlaceId);
            var seanceId = this.GetSeance().Id;
            var placeDTOChange = PlaceDTOManager.AssignIsBusyTo(placeDTO, seanceId, ticketService);

            Trace.WriteLine($"place id = {placeDTOChange.Id} isBusie = {placeDTOChange.IsBusy}");
        }

        [TestMethod]
        public void AssignIsBusyTo_isFalse_Test()
        {
            var ticketDTO = this.CreateAndGetTicketDTO();

            var placeDTO = placeService.GetOne(1);
            var seanceId = this.GetSeance().Id;
            var placeDTOChange = PlaceDTOManager.AssignIsBusyTo(placeDTO, seanceId, ticketService);

            Trace.WriteLine($"place id = {placeDTOChange.Id} isBusie = {placeDTOChange.IsBusy}");
        }

        public TicketDTO CreateAndGetTicketDTO()
        {
            var seanceDTO = this.GetSeance();

            var ticketDTO = new TicketDTO()
            {
                Id = "111111",
                SeanceId = seanceDTO.Id,
                State = 1,
                PlaceId = 10
            };

            ticketService.AddOrUpdate(ticketDTO);
            return ticketDTO;
        }

        public SeanceDTO GetSeance()
        {
            return seanceService.GetAll().FirstOrDefault();
        }
    }
}
