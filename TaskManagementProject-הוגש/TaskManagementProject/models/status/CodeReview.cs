using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using TaskManagementProject.interfaces;
using TaskManagementProject.models.task;


namespace TaskManagementProject.models.status
{
    internal class CodeReview : Status
    {
        public override int StatusCode => 3;

        

        public CodeReview(task.Task task) : base(task) { }
        public override void NextStatus(User? user = null)
        {
            Console.WriteLine("if code review finished succesfuly press 1 else press 2.");
            int answer = int.Parse(Console.ReadLine());
            switch (answer)
            {
                case 1:
                    if (user == null)
                    {
                        if (_task.PreviousAssignee is user.QA)
                        {
                            _task.Status = new QA(_task);
                            _task.Notify("Task status was changed to 'QA'");
                            var user1 = _task.PreviousAssignee;
                            _task.PreviousAssignee = _task.Assignee;
                            _task.Receivers.Remove(_task.Assignee);
                            _task.Assignee = user1;
                            _task.Receivers.Add(_task.Assignee);
                            return;
                        }
                        Console.WriteLine("you need to send to the function a QA that you are passing the task to.");
                        return;
                    }
                    else if (user is not models.user.QA)
                    {
                        Console.WriteLine("task can be passed for QA only to someone whos role is QA.");
                        return;
                    }
                    //if (_task.Assignee is not Manager)
                    //{
                    //    Console.WriteLine("only manager can do code review and pass task to QA");
                    //    return;
                    //}
                    _task.Status = new QA(_task);
                    _task.Notify("Task status was changed to 'QA'");
                    _task.PreviousAssignee = _task.Assignee;
                    _task.Receivers.Remove(_task.Assignee);
                    _task.Assignee = user;
                    _task.Receivers.Add(_task.Assignee);
                    break;
                case 2:
                    _task.Status = new Todo(_task);
                    _task.Notify("Task status was changed to 'to do'");
                    break;
                default:
                    Console.WriteLine("invalid choice - task did not move to next status");
                    break;
            }
        }
        public override string ToString()
        {
            return "code review";
        }
    }
}
