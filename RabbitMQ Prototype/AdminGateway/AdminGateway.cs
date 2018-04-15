using System;
using System.Collections.Generic;
using System.Text;
using EasyNetQ;
using Messages;

namespace AdminGateway
{
    public class AdminGateway
    {
        IBus bus = RabbitHutch.CreateBus("host=localhost");

        public AdminGateway()
        {
            bus.Receive<TextMessage>("responseQueue", message => HandleResponseMessage(message));
        }

        public void SendMessage(string message)
        {
            TextMessage tmessage = new TextMessage
            {
                Text = message
            };

            bus.Publish(message);
        }

        private void HandleResponseMessage(TextMessage textMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Got message: {0}", textMessage.Text);
            Console.ResetColor();
        }
    }
}
