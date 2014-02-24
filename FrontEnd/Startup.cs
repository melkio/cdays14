using MassTransit;
using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartup(typeof(FrontEnd.Startup))]

namespace FrontEnd
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            app.UseNancy();

            SetupServiceBus();
        }

        private void SetupServiceBus()
        {
            Bus.Initialize(c =>
                {
                    c.ReceiveFrom("rabbitmq://localhost/cdays14/frontend");
                    c.UseRabbitMqRouting();
                    c.UseJsonSerializer();
                });
        }
    }
}