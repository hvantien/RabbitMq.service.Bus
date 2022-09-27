using System;
using RabbitMq.Service.Bus.Events.Core;

namespace RabbitMq.Service.Bus.Events
{
    public class ScheduleNotificationIntegrationEvent : IntegrationEvent
    {
        /// <summary>
        /// JobId schedule
        /// </summary>
        public string JobId { get; set; }

        /// <summary>
        /// Execute Time
        /// </summary>
        public DateTime? ExecuteTime { get; set; }

        /// <summary>
        /// Info notification
        /// </summary>
        public NotificationInfomation NotificationInfomation { get; set; }
    }
}