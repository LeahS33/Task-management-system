using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManagementProject.interfaces;
using TaskManagementProject.models.task;
namespace TaskManagementProject.models.sorter_and_filter_task.sorter;

public class SortByEstimationTime : ISorter
{
    public List<task.Task> Sort(List<task.Task> tasks)
    {
        return tasks.OrderBy(t => t.EstimationTime).ToList();
    }
}
