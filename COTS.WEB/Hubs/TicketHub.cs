using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace COTS.WEB.Hubs
{
    public class TicketHub : Hub
    {
        public void Send(object[] places)
        {
            Clients.AllExcept(Context.ConnectionId).addData(places);
        }
    }
}