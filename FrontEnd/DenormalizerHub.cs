using Common;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;

namespace FrontEnd
{
    [HubName("denormalizer")]
    public class DenormalizerHub : Hub
    {
    }
}