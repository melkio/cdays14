using Commmon;
using Common;
using Common.DomainEvents;
using MassTransit;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;

namespace BackEnd.Consumers
{
    public class TalkDenormalizer : Consumes<TalkProposed>.Context, Consumes<TalkApproved>.Context
    {
        private readonly IMongoStorage _storage;

        public TalkDenormalizer() : this(new MongoStorage()) { }

        public TalkDenormalizer(IMongoStorage storage)
        {
            _storage = storage;
        }

        public void Consume(IConsumeContext<TalkProposed> context)
        {
            var message = context.Message;

            var document = new BsonDocument
                (
                    new BsonElement("_id", message.Id),
                    new BsonElement("speaker", message.Speaker),
                    new BsonElement("title", message.Title),
                    new BsonElement("abstract", message.Abstract),
                    new BsonElement("approved", false)
                );
            var collection = _storage.GetCollection("talks");
            collection.Insert(document);

            context.Bus.Publish(new ItemDenormalized { AggregateId = message.Id, DenormalizerName = "TalkDenormalizer", When = DateTime.Now });
        }

        public void Consume(IConsumeContext<TalkApproved> context)
        {
            var message = context.Message;

            var collection = _storage.GetCollection("talks");
            collection.Update(Query.EQ("_id", message.Id), Update.Set("approved", true));

            context.Bus.Publish(new ItemDenormalized { AggregateId = message.Id, DenormalizerName = "TalkDenormalizer", When = DateTime.Now });
        }
    }
}
