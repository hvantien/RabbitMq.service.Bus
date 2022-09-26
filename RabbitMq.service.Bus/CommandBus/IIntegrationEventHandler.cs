using RabbitMq.Service.Bus.Events.Core;
using System.Threading.Tasks;

namespace RabbitMq.Service.Bus.CommandBus
{
    public interface IIntegrationEventHandler<in T> where T : IntegrationEvent
    {
        Task Handle(T @event);
    }

    public interface IIntegrationEventHandler
    {
    }
}