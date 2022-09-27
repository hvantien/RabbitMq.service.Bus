using RabbitMq.Service.Bus.Events.Core;

namespace RabbitMq.Service.Bus.Events
{
    public class NotificationIntegrationEvent : IntegrationEvent
    {
        public NotificationInfomation NotificationInfomation { get; set; }
    }
}