using System;
using System.Collections.Generic;

namespace RabbitMq.Service.Bus.Events
{
    public class NotificationInfomation
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
    }
}