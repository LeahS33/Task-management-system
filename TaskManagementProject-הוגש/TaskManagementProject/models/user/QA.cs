using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.interfaces;


namespace TaskManagementProject.models.user
{
    public class QA : User
    {
        public QA(string name, string email)
        {
            CreateUser(name, email);
        }
        public override void CreateUser(string name, string email)
        {
            this.name = name;
            this.email = email;
            role = "QA";
        }
    }
}
