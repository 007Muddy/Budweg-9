using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBudweg.Model
{
   public class Employee
    {
        public int EmployeeID { get; set; }
        public string Department { get; set; }

        public Employee(int employeeID,string department )
        {
            EmployeeID = employeeID;
            Department = department;
            
        }

        public Employee() { }   
    }
}
