using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using TaskManagementProject.enums;
using TaskManagementProject.interfaces;
using TaskManagementProject.models.status;
using TaskManagementProject.models.notifications;

namespace TaskManagementProject.models.task
{
    public class Task : ITask
    {
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public User Assignee { get; set; }
        public User previousAssignee { get; set; }//אותו משתנה
        public User PreviousAssignee { get; set; }//אותו משתנה
        public User Reporter { get; set; }
        public Status Status { get; set; }
        public double EstimationTime { get; set; }
        public double LoggedTime { get; set; }
        public TaskPriority Priority { get; set; }
        public List<Subtask> SubTasks { get; set; }
        public Notification NotificationType { get; set; }
        public List<IReceiver> Receivers { get; set; }
        public Task()
        {
            CreationDate = DateTime.Now;
            Status = new Todo(this);
            NotificationType = new ConsoleNotice();
            SubTasks = new List<Subtask>();
        }
        public void Notify(string message)
        {
            foreach (var receiver in Receivers)
            {
                NotificationType.SendNotification(receiver, message);
            }
        }

        public void ChangePriority(TaskPriority changePriority)
        {
            if (Enum.IsDefined(typeof(TaskPriority), changePriority))
            {
                string message = $"The priority changed to {changePriority}";
                Notify(message);
                Priority = changePriority;

            }
            else
            {
                Console.WriteLine("Invalid priority value, The value has not been changed.");
            }
        }
        public void UpdateLoggedTime()
        {
            LoggedTime = SubTasks.Sum(subTask => subTask.LoggedTime);
        }
        public virtual void AddLoggedTime(double loggedTime)
        {
            if (loggedTime < 0)
            {
                Console.WriteLine("Logged time cannot be negative, The value has not been changed.");
                return;
            }
            if (SubTasks.Count == 0)
            {
                LoggedTime += loggedTime;
                return;
            }
            LoggedTime = SubTasks.Sum(subTask => subTask.LoggedTime) + loggedTime;
        }
        public void AddSubtask(Subtask subtask)
        {
            subtask.ParentTask = this;
            SubTasks.Add(subtask);
            UpdateLoggedTime();
             EstimationTime = 0;
            foreach (Subtask subTask in SubTasks)
            {
                EstimationTime += subtask.EstimationTime;
            }
        }
    }
}
