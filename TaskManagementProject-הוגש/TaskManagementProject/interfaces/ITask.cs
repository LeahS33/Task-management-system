using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementProject.interfaces
{
    public interface ITask
    {
        public double EstimationTime { get; set; }
        public double LoggedTime { get; set; }
        public void AddLoggedTime(double loggedTime);
          
    }
}
