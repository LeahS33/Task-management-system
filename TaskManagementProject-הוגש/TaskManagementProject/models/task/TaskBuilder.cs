using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.enums;
using TaskManagementProject.interfaces;


namespace TaskManagementProject.models.task
{
    public class TaskBuilder
    {
        public string Title { get; set; }
        public string? Description = null;
        public User Assignee { get; set; }
        public User? previousAssignee = null;
        public User Reporter { get; set; }
        // public Status? Status;
        public TaskPriority? Priority = null;
        public double? EstimationTime = null;
        public double? LoggedTime = 0.0;
        public List<IReceiver> Receivers { get; set; }
        //public List<IReceiver>? Receivers= new List<IReceiver>();
        public TaskBuilder(string title, User assignee, User reporter)
        {
            Title = title;
            Assignee = assignee;
            Reporter = reporter;
            Receivers = [Assignee, Reporter];//לא בטוח טוב
        }

        public TaskBuilder BuildDescription(string description)
        {
            Description = description;
            return this;
        }

        public TaskBuilder BuildPriority(TaskPriority priority)
        {

            if (Enum.IsDefined(typeof(TaskPriority), priority))
            {
                Priority = priority;
            }
            else
            {
                Console.WriteLine("Invalid priority value, the value has not been changed.");
            }
            return this;
        }

        //public TaskBuilder BuildLoggedTime(double additionalTime)
        //{
        //    if (additionalTime < 0)
        //        throw new ArgumentException("Logged time cannot be negative.");
        //    if (HasSubTasks && SubTasks.Count > 0)
        //    {
        //        LoggedTime = SubTasks.Sum(t => t.LoggedTime);
        //    }
        //    else
        //    {
        //        LoggedTime += additionalTime;
        //    }
        //    return this;
        //}
        //public TaskBuilder BuildNotificationType(Notification notificationType)//הוא לא צריך לקבל הודעה שTASK נבנה
        //{
        //    NotificationType = notificationType;
        //    return this;
        //}
        public TaskBuilder BuildEstimationTime(double estimationTime)
        {
            if (estimationTime < 0)
                Console.WriteLine("Logged time cannot be negative, the value has not been changed");
            else EstimationTime = estimationTime;
            return this;
        }
        public virtual Task build()
        {
            return new Task()
            {
                Title = Title,
                Description = Description,
                Assignee = Assignee,
                Reporter = Reporter,
                Receivers = Receivers,
                Priority = (TaskPriority)Priority,
                EstimationTime = (double)EstimationTime,
                LoggedTime = (double)LoggedTime
            };
        }
    }
}
