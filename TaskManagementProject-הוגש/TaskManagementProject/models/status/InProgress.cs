using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.interfaces;
using TaskManagementProject.models.task;
using TaskManagementProject.models.user;

namespace TaskManagementProject.models.status
{
    internal class InProgress : Status
    {
        public override int StatusCode => 2;
        public InProgress(task.Task task) : base(task) { }
        public override void NextStatus(User? user = null)
        {
            if (user == null)
            {
                Console.WriteLine("you need to send to the function the manager that you are passing the task to for code review.");
                return;
            }
            else if (user is not Manager)
            {
                Console.WriteLine("task can be passed for code review only to someone whos role is manager.");
                return;
            }
            if (user != _task.Reporter)
            {
                Console.WriteLine("only manager who gave the task can review it.");
                return;
            }
            _task.Status = new CodeReview(_task);
            _task.Notify("Task status was changed to 'code review'");
            //_task.PreviousAssignee=_task.Assignee;
            //_task.Receivers.Remove(_task.Assignee);
            //_task.Assignee = _task.Reporter;
        }
        public override string ToString()
        {
            return "in progress";
        }
    }
}
