using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementProject.interfaces
{
    public abstract class Notification
    {
        public abstract void SendNotification(IReceiver receiver, string message);
    }
}
