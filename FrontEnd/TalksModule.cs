using Commmon;
using Common.Commands;
using MassTransit;
using MongoDB.Bson;
using Nancy;
using Nancy.ModelBinding;
using System;
using System.Linq;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using FrontEnd.Models;

namespace FrontEnd
{
    public class TalksModule : NancyModule
    {
        public TalksModule() : base("talks")
        {
            Get[""] = p =>
            {
                var storage = new MongoStorage();
                var collection = storage.GetCollection<TalkModel>("talks");

                return collection.FindAll();
            };

            Post[""] = p =>
            {
                var command = this.Bind<CreateTalkCommand>();
                Bus.Instance.Publish(command);

                return HttpStatusCode.Created;
            };
        }
    }


}