using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.interfaces;

namespace TaskManagementProject.models.sorter_and_filter_task
{
    class Context
    {
        private IFilter filter = null;
        private ISorter sorter = null;
        public void SetFilter(IFilter filter)
        {
            this.filter = filter;
        }
        public void SetSorter(ISorter sorter)
        {
            this.sorter = sorter;
        }
        public List<task.Task> SortAndFilter(List<task.Task> tasks)
        {
            if (filter != null)
            {
                tasks = filter.Filter(tasks); 
            }

            if (sorter != null)
            {
                tasks = sorter.Sort(tasks); 
            }
            if(sorter == null && filter == null)
            {
                Console.WriteLine("Can't sort or filter, enter valueValue for sorting or filtering has not been provided.");
            }


            return tasks;
        }
    }
 }
