using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.enums;
using TaskManagementProject.interfaces;

namespace TaskManagementProject.models.task
{
    public class SubTaskBuilder : TaskBuilder
    {
        public Task ParentTask { get; set; }
        public SubTaskBuilder(string title, User assignee, User reporter) : base(title, assignee, reporter) { }
        public override Subtask build()
        {
            return new Subtask(ParentTask)
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
