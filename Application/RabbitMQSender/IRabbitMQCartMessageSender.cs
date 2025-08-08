using OnlineShop.Application.DTOs;
using OnlineShop.Application.RabbitMQSender.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.RabbitMQSender
{
    public interface IRabbitMQCartMessageSender
    {
        void SendMessage(string value);
    }
}
