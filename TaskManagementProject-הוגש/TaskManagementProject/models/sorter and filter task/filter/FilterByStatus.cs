using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.interfaces;

namespace TaskManagementProject.models.sorter_and_filter_task.filter
{
    public class FilterByStatus: IFilter
    {
        private Status _status;

        public FilterByStatus(Status status)
        {
            _status = status;
        }

        public List<task.Task> Filter(List<task.Task> tasks)
        {
            return tasks.Where(t => t.Status.ToString() == _status.ToString()).ToList();
        }
    }
}
