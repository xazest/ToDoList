using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using TodoList.Application.Interfaces;
using TodoList.Domain;

namespace TodoList.Application.Aggregates.UserProfiles.Events
{
    public class UserRegisteredEvent : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public UserRegisteredEvent(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken ct)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = await factory.CreateConnectionAsync(ct);
            using var channel = await connection.CreateChannelAsync(cancellationToken: ct);

            await channel.QueueDeclareAsync(queue: "user_registered_queue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null,
                cancellationToken: ct
            );

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (sender, e) =>
            {
                var body = Encoding.UTF8.GetString(e.Body.ToArray());
                var userId = Guid.Parse(body);

                using var scope = _scopeFactory.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<ITodoListDbContext>();

                var profile = new UserProfile
                {
                    Id = Guid.NewGuid().ToString(),//логика для создания Id дописать
                    UserId = userId,
                    Nickname = "NewUser",
                    AvatarUrl = null
                };

                dbContext.UserProfiles.Add(profile);
                await dbContext.SaveChangesAsync(ct);
            };

            await channel.BasicConsumeAsync(queue: "user_registered_queue",
                autoAck: true,
                consumer: consumer,
                cancellationToken: ct
            );

            return;
        }
    }
}
