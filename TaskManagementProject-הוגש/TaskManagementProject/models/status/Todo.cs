using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.interfaces;

using TaskManagementProject.models.task;

namespace TaskManagementProject.models.status
{
    internal class Todo : Status
    {
        public override int StatusCode => 1;
        public Todo(task.Task task) : base(task) { }
        public override void NextStatus(User? user = null)
        {
            _task.Status = new InProgress(_task);
            _task.Notify("Task status was changed to 'in progress'");
        }
        public override string ToString()
        {
            return "to do";
        }
    }
}