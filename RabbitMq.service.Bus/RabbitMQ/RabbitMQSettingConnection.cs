using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMq.Service.Bus.Abstractions;
using RabbitMq.Service.Bus.Events.Core;
using RabbitMQ.Client;

namespace RabbitMq.Service.Bus.RabbitMQ
{
    public static class RabbitMQSettingConnection
    {
        public static void RegisterEventBus(IServiceCollection services,
                        IConfiguration configuration,
                        string session = "RabitMQConfiguration")
        {
            services.Configure<RabitMQConfiguration>(configuration.GetSection(session));

            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var rabitMQConfiguration = new RabitMQConfiguration();
                configuration.GetSection(session).Bind(rabitMQConfiguration);

                var logger = sp.GetRequiredService<ILogger<RabbitMQPersistentConnection>>();

                var factory = new ConnectionFactory()
                {
                    HostName = rabitMQConfiguration.HostName,
                };

                if (!string.IsNullOrEmpty(rabitMQConfiguration.UserName))
                    factory.UserName = rabitMQConfiguration.UserName;

                if (!string.IsNullOrEmpty(rabitMQConfiguration.Password))
                    factory.Password = rabitMQConfiguration.Password;

                if (!string.IsNullOrEmpty(rabitMQConfiguration.VirtualHost))
                    factory.VirtualHost = rabitMQConfiguration.VirtualHost;

                if (rabitMQConfiguration.Port.HasValue)
                    factory.Port = rabitMQConfiguration.Port.Value;

                return new RabbitMQPersistentConnection(factory, logger, rabitMQConfiguration.RetryCount);
            });

            services.AddSingleton<IEventBusRabbitMQ, EventBusRabbitMQ>(sp =>
            {
                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                var rabitMQConfiguration = new RabitMQConfiguration();
                configuration.GetSection(session).Bind(rabitMQConfiguration);

                return new EventBusRabbitMQ(rabbitMQPersistentConnection,
                    logger, iLifetimeScope, eventBusSubcriptionsManager,
                    queueName: rabitMQConfiguration.QueueName,
                    exchangetype: rabitMQConfiguration.Exchangetype,
                    exchangeName: rabitMQConfiguration.ExchangeName,
                    retryCount: rabitMQConfiguration.RetryCount);
            });

            // EventBusSubscriptionsManager
            services.AddSingleton<IEventBusSubscriptionsManager, EventBusSubscriptionsManager>();
        }
    }
}