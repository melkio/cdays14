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
        }
    }
}