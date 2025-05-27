using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.interfaces;

namespace TaskManagementProject.models.notifications
{
    internal class ConsoleNotice : Notification
    {
        public override void SendNotification(IReceiver receiver, string message)
        {
            Console.Write($"message send to: {((User)receiver).name} - ");
            receiver.ReceiveMessage(message);
        }
    }
}
