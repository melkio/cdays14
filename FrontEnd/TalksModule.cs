using Nancy;
using System;

namespace FrontEnd
{
    public class TalksModule : NancyModule
    {
        public TalksModule() : base("talks")
        {
            Get[""] = p =>
            {
                return new[] { new { Id = 1, speaker = "Alessandro", title = "SignalR" } };
            };
        }
    }
}