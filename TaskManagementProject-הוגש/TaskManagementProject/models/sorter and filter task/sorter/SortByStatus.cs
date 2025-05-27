using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.interfaces;

namespace TaskManagementProject.models.sorter_and_filter_task.sorter
{
    public class SortByStatus : ISorter
    {
        public List<task.Task> Sort(List<task.Task> tasks)
        {
           return tasks.OrderBy(t => t.Status.StatusCode).ToList();
        }
    }
}
