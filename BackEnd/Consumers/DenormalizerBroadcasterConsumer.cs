using Common;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace BackEnd.Consumers
{
    public class DenormalizerBroadcasterConsumer : Consumes<ItemDenormalized>.All
    {
        public void Consume(ItemDenormalized message)
        {
            using (var client = new HttpClient())
            {
                var properties = new[] 
                { 
                    new KeyValuePair<String, String>("DenormalizerName", message.DenormalizerName), 
                    new KeyValuePair<String, String>("AggregateId", message.AggregateId), 
                    new KeyValuePair<String, String>("When", message.When.ToString("yyyyMMdd hhmmss"))
                };
                var content = new FormUrlEncodedContent(properties);

                client.BaseAddress = new Uri("http://localhost:49180");
                client.PostAsync("/denormalizer/notify", content).Wait();
            }
        }
    }
}
