using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementProject.interfaces
{
    public abstract class User : IReceiver
    {
        public string name { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        abstract public void CreateUser(string name, string email);
        public void ReceiveMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
