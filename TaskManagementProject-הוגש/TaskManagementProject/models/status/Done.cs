using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.interfaces;
using TaskManagementProject.models.task;

namespace TaskManagementProject.models.status
{
    internal class Done : Status
    {
        public override int StatusCode => 5;
        public Done(task.Task task) : base(task) { }
        public override void NextStatus(User? user = null)
        {
            Console.WriteLine("task is allready done");
        }
        public override string ToString()
        {
            return "done";
        }
    }
}
