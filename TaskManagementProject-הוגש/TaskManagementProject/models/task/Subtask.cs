using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementProject.models.task
{
    public class Subtask : Task
    {
        public Task ParentTask { get; set; }

        public Subtask(Task parentTask)
        {
            ParentTask = parentTask;
        }

        public override void AddLoggedTime(double loggedTime)
        {
            if (loggedTime < 0)
            {
                Console.WriteLine("Logged time cannot be negative, The value has not been changed.");
                return;
            }
            LoggedTime += loggedTime;
            ParentTask?.UpdateLoggedTime();
        }
    }
}
