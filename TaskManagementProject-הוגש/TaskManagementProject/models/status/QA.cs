using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.interfaces;
using TaskManagementProject.models.task;
using TaskManagementProject.models.status;

namespace TaskManagementProject.models.status
{
    internal class QA : Status
    {
        public override int StatusCode => 4;
        public QA(task.Task task) : base(task) { }
        public override void NextStatus(User? user = null)
        {
            Console.WriteLine("if QA was finished succesfuly press 1 else press 2.");
            int answer = int.Parse(Console.ReadLine());
            switch (answer)
            {
                case 1:
                    //if (_task.Assignee is not TaskManagementProject.user.QA)
                    //{
                    //    Console.WriteLine("only QA can mark a task as done.");
                    //    return;
                    //}
                    if (_task.SubTasks.Count > 0)
                    {
                        foreach (var task in _task.SubTasks)
                        {
                            if (task.Status.Equals("status: done"))
                                continue;
                            else
                            {
                                Console.WriteLine("task status can not be done untill all his subtasks arr done.");
                                return;
                            }
                        }
                    }
                    _task.Status = new Done(_task);
                    _task.Notify("Task status was changed to 'done'");
                    break;
                case 2:
                    _task.Status = new Todo(_task);
                    _task.Notify("Task status was changed to 'to do'");
                    var user1 = _task.PreviousAssignee;
                    _task.PreviousAssignee = _task.Assignee;
                    _task.Receivers.Remove(_task.Assignee);
                    _task.Assignee = user1;
                    _task.Receivers.Add(_task.Assignee);
                    break;
                default:
                    Console.WriteLine("invalid choice - task did not move to next status");
                    break;
            }
        }
        public override string ToString()
        {
            return "QA";
        }
    }
}
