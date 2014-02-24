using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartup(typeof(SignalR.Intro.Startup))]

namespace SignalR.Intro
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}