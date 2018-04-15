using System;
using System.Collections.Generic;
using System.Text;

namespace Admin
{
    public class Admin
    {
        private AdminGateway.AdminGateway gateway;
        public void Start()
        {
            gateway = new AdminGateway.AdminGateway();
            var input = "";
            Console.WriteLine("Enter a message. 'Quit' to quit.");
            while ((input = Console.ReadLine()) != "Quit")
            {
                gateway.SendMessage(input);
            }
        }
    }
}
