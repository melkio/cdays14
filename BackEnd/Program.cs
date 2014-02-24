using BackEnd.Consumers;
using MassTransit;
using System;

namespace BackEnd
{
    class Program
    {
        static void Main(String[] args)
        {
            Bus.Initialize(c =>
            {
                c.ReceiveFrom("rabbitmq://localhost/cdays14/backend");
                c.UseRabbitMqRouting();
                c.UseJsonSerializer();

                c.Subscribe(x =>
                    {
                        x.Consumer<CreateTalkCommandHandler>();
                        x.Consumer<TalkDenormalizer>();
                    });
            });

            Console.ReadLine();
        }
    }
}
