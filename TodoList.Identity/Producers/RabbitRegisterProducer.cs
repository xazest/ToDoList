using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using TodoList.Identity.Interfaces;

namespace TodoList.Identity.Producers
{
    public class RabbitRegisterProducer : IRabbitRegisterProducer
    {
        public async Task ProduceAsync(string queueName, string userId)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
                queue: queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            var body = Encoding.UTF8.GetBytes(userId);

            //await channel.ExchangeDeclareAsync(
            //    exchange: "user_registered",
            //    type: ExchangeType.Fanout
            //);

            await channel.BasicPublishAsync(
                exchange: string.Empty,
                routingKey: queueName,
                body: body
            );
        }
    }
}
