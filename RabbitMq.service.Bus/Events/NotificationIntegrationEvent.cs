using RabbitMq.Service.Bus.Events.Core;
using System;
using System.Collections.Generic;

namespace RabbitMq.Service.Bus.Events
{
    public class NotificationIntegrationEvent : IntegrationEvent
    {
        public string Key { get; set; }

        /// <summary>
        /// The user ids
        /// </summary>
        public List<UserInfomation> Receivers { get; set; }

        /// <summary>
        /// get or set title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// get or set image url
        /// </summary>
        public string ImageURL { get; set; }

        /// <summary>
        /// The request
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The RefId
        /// </summary>
        public string RefId { get; set; }

        /// <summary>
        /// The RefId
        /// </summary>
        public UserInfomation Sender { get; set; }

        /// <summary>
        /// The Param
        /// </summary>
        public string Parameters { get; set; }

        /// <summary>
        /// Date send notification
        /// </summary>
        /// <value></value>
        public DateTime? DateSendNotification { get; set; }
    }

    public class UserInfomation
    {
        /// <summary>
        /// UserId
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }
    }
}