using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;

namespace SignalR.Intro
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        public void BroadcastMessage(String message)
        {
            Clients.All.showMessage(message);
        }
    }
}