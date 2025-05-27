using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.models.task;

namespace TaskManagementProject.interfaces
{
    public abstract class Status
    {
        protected models.task.Task _task;
        public abstract int StatusCode { get; }
        protected Status(models.task.Task task)
        {
            _task = task;
        }
        abstract public void NextStatus(User? user = null);
        public abstract override string ToString();
    }
}
