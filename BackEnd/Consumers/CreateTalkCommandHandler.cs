using Common.Commands;
using MassTransit;
using System;
using System.Linq;

namespace BackEnd.Consumers
{
    public class CreateTalkCommandHandler : Consumes<CreateTalkCommand>.Context
    {
        public void Consume(IConsumeContext<CreateTalkCommand> context)
        {
            var message = context.Message;

            var talk = new Talk();
            var events = talk.Propose(message.Speaker, message.Title, message.Abstract);

            Array.ForEach(events.ToArray(), e => context.Bus.Publish(e, e.GetType()));
        }
    }
}
