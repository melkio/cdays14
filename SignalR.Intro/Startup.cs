using Microsoft.AspNet.SignalR;
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
            GlobalHost.DependencyResolver.UseRedis("localhost", 6379, "", "cdays14"); 
            app.MapSignalR();
        }
    }
}