using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using EasyNetQ;
using Messages;

namespace InfoViewerGateway
{
    public class InfoViewerGateway
    {
        IBus bus = RabbitHutch.CreateBus("host=localhost");

        public InfoViewerGateway()
        {
            bus.Subscribe<TextMessage>("subscriber", HandleTextMessage);
            lock (this)
            {
                Monitor.Wait(this);
            }
        }

        public void RespondToMessage(string message)
        {
            bus.Send("responseQueue", new TextMessage
            {
                Text = "hello"
            });
        }

        private void HandleTextMessage(TextMessage textMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Got message: {0}", textMessage.Text);
            Console.ResetColor();

        }
    }

}
