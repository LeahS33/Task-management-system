using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementProject.models
{
    public interface IFilter
    {
        List<TaskManagementProject.models.task.Task> Filter(List<TaskManagementProject.models.task.Task> tasks);
    }
}
