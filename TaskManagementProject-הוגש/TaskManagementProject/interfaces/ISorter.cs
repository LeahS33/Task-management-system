using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementProject.interfaces
{
    public interface ISorter
    {
        List<TaskManagementProject.models.task.Task> Sort(List<TaskManagementProject.models.task.Task> tasks);
        
    }
}
