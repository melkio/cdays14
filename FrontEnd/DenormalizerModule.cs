using Common;
using Microsoft.AspNet.SignalR;
using Nancy;
using Nancy.ModelBinding;
using System;

namespace FrontEnd
{
    public class DenormalizerModule : NancyModule
    {
        public DenormalizerModule() : base("denormalizer")
        {
            Post["notify"] = p =>
            {
                var message = this.Bind<ItemDenormalized>();

                var hub = GlobalHost.ConnectionManager.GetHubContext<DenormalizerHub>();
                hub.Clients.All.notify(message);

                return HttpStatusCode.Created;
            };
        }
    }
}