using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementProject.interfaces
{
    public interface IReceiver
    {
        void ReceiveMessage(string message);
    }
}
