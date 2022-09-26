using RabbitMq.Service.Bus.CommandBus;
using RabbitMq.Service.Bus.Events.Core;

namespace RabbitMq.Service.Bus.RabbitMQ
{
    public interface IEventBusRabbitMQ
    {
        void Publish(IntegrationEvent @event);

        void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>;

        void Unsubscribe<T, TH>()
            where TH : IIntegrationEventHandler<T>
            where T : IntegrationEvent;
    }
}